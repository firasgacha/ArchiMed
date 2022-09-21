import React, { useEffect, useMemo, useState } from "react";
import { useTable, useSortBy, useGlobalFilter, useFilters, usePagination, useColumnOrder, useRowSelect } from "react-table";
import GlobalFilter from "../../components/GlobalFilter";
import ColumnFilter from "components/ColumnFilter";
import axios from "axios";
import { useQuery } from "react-query";
import ImageBalise from "./ImageBalise";


export default function ListOfDepartements() {
  const DoctorsCOLUMNS = [
    {
      Header: '',
      accessor: 'imageUrl',
      Cell: ({ value }) => (value != "Empty" ? <ImageBalise image={value} /> : <img src="src/assets/upload.svg" alt="upload" className="h-[50px] w-[50px]" />
      ),
      Filter: ColumnFilter
    },
    {
      Header: 'First Name',
      accessor: 'fisrtName',
      Filter: ColumnFilter
    },
    {
      Header: 'Last Name',
      accessor: 'lastName',
      Filter: ColumnFilter
    },
    {
      Header: 'Gender',
      accessor: 'gender',
      Filter: ColumnFilter,
      Cell: ({ value }) => (value == 'Male' ?
        <div className="ml-6"><MaleSvg /></div> : <div className="ml-6"><FemaleSvg /></div>)
    },
    {
      Header: 'Specialty',
      accessor: 'specialty',
      Filter: ColumnFilter
    },
    {
      Header: 'Department',
      accessor: 'departmentFk',
      Filter: ColumnFilter,
      Cell: ({ value }) => (value ?
        <button onClick={() => {
          getDepartementById(value);
          setshowDepartment(!showDepartment);
        }} className="ml-3 rounded-full bg-green-400 text-white text-sm px-6 py-2 flex justify-center items-center">See</button>
        : 'Not affected')
    },
    {
      Header: 'Head of department',
      accessor: 'headofDepartment',
      Cell: ({ cell: { value } }) => (value ? 'Yes' : 'No'),
      Filter: ColumnFilter
    },
    {
      Header: 'CIN',
      accessor: 'cin',
      Filter: ColumnFilter
    },
    {
      Header: 'Birthday',
      accessor: 'birthday',
      Filter: ColumnFilter,
      // Cell: ({ cell: { value } }) => format(new Date(value), 'dd/MM/yyyy')
    },
    {
      Header: 'Email',
      accessor: 'email',
      Filter: ColumnFilter
    },
    {
      Header: 'Phone',
      accessor: 'phone',
      Filter: ColumnFilter
    },
    {
      Header: 'Adress',
      accessor: 'adress',
      Filter: ColumnFilter
    },
    {
      Header: 'Postal_Code',
      accessor: 'postalCode',
      Filter: ColumnFilter
    },

    {
      Header: 'City',
      accessor: 'city',
      Filter: ColumnFilter
    },
    {
      Header: 'Country',
      accessor: 'country',
      Filter: ColumnFilter
    }
  ]
  const COLUMNS = [
    {
      Header: 'Department Name',
      accessor: 'departmentName',
      Filter: ColumnFilter
    },
    {
      Header: 'Doctors List',
      accessor: 'departmentId',
      Filter: ColumnFilter,
      Cell: ({ value }) => (value ?
        <button onClick={async() => {
          await GetDoctorByDepartement(value);
          setshowDoctorsList(!showDoctorsList);
          console.log(showDoctorsList);
        }} className="ml-3 rounded-full bg-green-400 text-white text-sm px-6 py-2 text-center">See</button>
        : 'Empty')
    }
  ]

  const [departmentsListData, setDepartmentsListData] = useState([]);
  const [showAddDepartment, setshowAddDepartment] = useState(false);
  const [showEditDepartment, setshowEditDepartment] = useState(false);
  const [showDoctorsList, setshowDoctorsList] = useState(false);


  const [departmentId, setdepartmentId] = useState(Number);
  const [departmentName, setdepartmentName] = useState(String);
  const [departmentdoctorsList, setdepartmentdoctorsList] = useState(null);
  
  const [doctorsList, setdoctorsList] = useState([]);

  const fetchDepartemnetsData = async () => {
    await axios.get('Department')
      .then((res) => {
        setDepartmentsListData(res.data);
      }).catch((err) => {
        console.log(err);
      })
  }

  const { data, isLoading, isFetched } = useQuery("Department", fetchDepartemnetsData);

  
  const GetDoctorByDepartement = async (id: number) => {
    await axios.get(`Doctor/GetDoctorByDepartement/${id}`)
      .then((res) => {
        console.log(res.data);
        setdoctorsList(res.data);
      }).catch((err) => {
        console.log(err);
      })
  }


  const columns = useMemo(() => COLUMNS, []);
  const data2 = useMemo(() => departmentsListData, [departmentsListData]);

  const { allColumns, selectedFlatRows, getToggleHideAllColumnsProps, getTableProps, getTableBodyProps, headerGroups, footerGroups, page, nextPage, previousPage, setPageSize, setColumnOrder, canNextPage, canPreviousPage, pageOptions, gotoPage, pageCount, prepareRow, state, setGlobalFilter } =
    useTable({
      columns,
      data: data2,
      initialState: { pageIndex: 0, pageSize: 10 }
    },
      useColumnOrder,
      useFilters,
      useGlobalFilter,
      useSortBy,
      usePagination,
      useRowSelect,
      (hooks) => {
        hooks.visibleColumns.push((columns) => {
          return [{
            id: 'selection',
            Header: ({ getToggleAllRowsSelectedProps }) => (
              <input type="checkbox" {...getToggleAllRowsSelectedProps()} />
            ),
            Cell: ({ row }) => (
              <input type="checkbox" {...row.getToggleRowSelectedProps()} />
            )
          },
          ...columns
          ]
        })
      }
    );

  const { pageIndex, pageSize } = state;

  const { globalFilter } = state;

  const changeOrdre = (v: String) => {
    switch (v) {
      case "Name": {
        setColumnOrder(['departmentName']);
        break;
      }
      default: {
        break;
      }
    }
  }
  const [isList, setIsList] = useState(false);

  const departement = {
    "departmentId": departmentId,
    "departmentName": departmentName,
    "doctors": departmentdoctorsList
  }

  const deleteDepartement = async () => {
    selectedFlatRows.map(async (row) => {
      await axios.delete(`Department/${row.original.departmentId}`)
        .then((res) => {
          fetchDepartemnetsData();
        }).catch((err) => {
          console.log(err);
        })
    })
    alert("Doctor deleted");
  }
  const addDepartement = async () => {
    await axios.post('Department', { "departmentName": departmentName, "doctors": departmentdoctorsList })
      .then((res) => {
        alert("Departement added");
        fetchDepartemnetsData();
        setdepartmentId(0);
      }).catch((err) => {
        console.log(err);
      }
      )
  }

  const editDepartement = async () => {
    setdepartmentdoctorsList([]);
    await axios.put(`Department/${departmentId}`, {
      "departmentId": departmentId,
      "departmentName": departmentName,
      "doctors": departmentdoctorsList
    })
      .then((res) => {
        alert("Departement updated");
        fetchDepartemnetsData();
      }).catch((err) => {
        console.log(err.message);
      }
      )
  }

  const EditFunction = () => {
    if (selectedFlatRows.length === 1) {
      selectedFlatRows.map(async (row) => {
        setdepartmentId(row.original.departmentId);
        setdepartmentName(row.original.departmentName);
        setdepartmentdoctorsList(row.original.doctorsList);
      })
      setshowEditDepartment(!showEditDepartment);
    }
  }

  

  useEffect(() => {
    fetchDepartemnetsData();
    setdepartmentdoctorsList([]);
  }, [])


  return (
    <>
      {showAddDepartment &&
        < div id="Add" className="z-50 fixed w-full flex justify-center inset-0">
          <div className="w-full h-full bg-gray-500 bg-opacity-75 transition-opacity z-0 absolute inset-0" />
          <div className="mx-auto container">
            <div className="flex items-center justify-center h-full w-full">
              <div className="bg-white rounded-md shadow fixed overflow-y-auto sm:h-auto w-10/12 md:w-8/12 lg:w-1/2 2xl:w-2/5">
                <div className="bg-gray-100 rounded-tl-md rounded-tr-md px-4 md:px-8 md:py-4 py-7 flex items-center justify-between">
                  <p className="text-base font-semibold">Create New Departement</p>
                  <button className="focus:outline-none">
                    <svg onClick={() => setshowAddDepartment(!showAddDepartment)} width={20} height={20} viewBox="0 0 28 28" fill="none" xmlns="http://www.w3.org/2000/svg">
                      <path d="M21 7L7 21" stroke="#A1A1AA" strokeWidth="1.75" strokeLinecap="round" strokeLinejoin="round" />
                      <path d="M7 7L21 21" stroke="#A1A1AA" strokeWidth="1.75" strokeLinecap="round" strokeLinejoin="round" />
                    </svg>
                  </button>
                </div>
                <div className="px-4 md:px-10 pt-6 md:pt-12 md:pb-4 pb-7">
                  <form className="mt-2">
                    <div className="flex items-center space-x-9 justify-center">
                      <input onChange={(e) => setdepartmentName(e.target.value)} placeholder="Department Name" type="text" className="w-1/2 focus:outline-none placeholder-gray-500 py-3 px-3 text-sm leading-none text-gray-800 bg-white border rounded border-gray-200" />
                    </div>
                  </form>
                  <div className="flex items-center justify-between mt-9">
                    <button onClick={() => setshowAddDepartment(!showAddDepartment)} className="px-6 py-3 bg-gray-400 hover:bg-gray-500 shadow rounded text-sm text-white">
                      Cancel
                    </button>
                    <button onClick={() => addDepartement()} className="px-6 py-3 bg-indigo-700 hover:bg-opacity-80 shadow rounded text-sm text-white">Confirm</button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      }
      {showEditDepartment &&
        < div id="edit" className="z-50 fixed w-full flex justify-center inset-0">
          <div className="w-full h-full bg-gray-500 bg-opacity-75 transition-opacity z-0 absolute inset-0" />
          <div className="mx-auto container">
            <div className="flex items-center justify-center h-full w-full">
              <div className="bg-white rounded-md shadow fixed overflow-y-auto sm:h-auto w-10/12 md:w-8/12 lg:w-1/2 2xl:w-2/5">
                <div className="bg-gray-100 rounded-tl-md rounded-tr-md px-4 md:px-8 md:py-4 py-7 flex items-center justify-between">
                  <p className="text-base font-semibold">Edit Departement</p>
                  <button className="focus:outline-none">
                    <svg onClick={() => setshowEditDepartment(!showEditDepartment)} width={20} height={20} viewBox="0 0 28 28" fill="none" xmlns="http://www.w3.org/2000/svg">
                      <path d="M21 7L7 21" stroke="#A1A1AA" strokeWidth="1.75" strokeLinecap="round" strokeLinejoin="round" />
                      <path d="M7 7L21 21" stroke="#A1A1AA" strokeWidth="1.75" strokeLinecap="round" strokeLinejoin="round" />
                    </svg>
                  </button>
                </div>
                <div className="px-4 md:px-10 pt-6 md:pt-12 md:pb-4 pb-7">
                  <form className="mt-2">
                    <div className="flex items-center space-x-9 justify-center">
                      <input defaultValue={departmentName} onChange={(e) => setdepartmentName(e.target.value)} placeholder="Department Name" type="text" className="w-1/2 focus:outline-none placeholder-gray-500 py-3 px-3 text-sm leading-none text-gray-800 bg-white border rounded border-gray-200" />
                    </div>
                  </form>
                  <div className="flex items-center justify-between mt-9">
                    <button onClick={() => setshowEditDepartment(!showEditDepartment)} className="px-6 py-3 bg-gray-400 hover:bg-gray-500 shadow rounded text-sm text-white">
                      Cancel
                    </button>
                    <button onClick={() => editDepartement()} className="px-6 py-3 bg-indigo-700 hover:bg-opacity-80 shadow rounded text-sm text-white">Save changes</button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      }

      {/* <code>
        {JSON.stringify(
          {
            selectedFlatRows: selectedFlatRows.map((row) => row.original),
          },
          null,
          2
        )}
        {JSON.stringify(departement)}
      </code> */}
      <div id="listOfDoctors">
        <div className="bg-white p-10 2xl:p-5">
          <div className="container mx-auto bg-white rounded">
            <div className="flex justify-between border-b border-gray-300 py-5 bg-white">
              <div className="flex mx-auto xl:w-full xl:mx-0 items-center">
                {/* <p className="text-lg text-gray-800 font-bold mr-3">List of departements</p> */}
                <svg onClick={() => setshowAddDepartment(!showAddDepartment)} xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-6 h-6">
                  <path strokeLinecap="round" strokeLinejoin="round" d="M18 7.5v3m0 0v3m0-3h3m-3 0h-3m-2.25-4.125a3.375 3.375 0 11-6.75 0 3.375 3.375 0 016.75 0zM3 19.235v-.11a6.375 6.375 0 0112.75 0v.109A12.318 12.318 0 019.374 21c-2.331 0-4.512-.645-6.374-1.766z" />
                </svg>
                <svg onClick={() => EditFunction()} xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-6 h-6 ml-3">
                  <path strokeLinecap="round" strokeLinejoin="round" d="M16.862 4.487l1.687-1.688a1.875 1.875 0 112.652 2.652L10.582 16.07a4.5 4.5 0 01-1.897 1.13L6 18l.8-2.685a4.5 4.5 0 011.13-1.897l8.932-8.931zm0 0L19.5 7.125M18 14v4.75A2.25 2.25 0 0115.75 21H5.25A2.25 2.25 0 013 18.75V8.25A2.25 2.25 0 015.25 6H10" />
                </svg>
                <svg onClick={() => deleteDepartement()} xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-6 h-6 ml-3">
                  <path strokeLinecap="round" strokeLinejoin="round" d="M14.74 9l-.346 9m-4.788 0L9.26 9m9.968-3.21c.342.052.682.107 1.022.166m-1.022-.165L18.16 19.673a2.25 2.25 0 01-2.244 2.077H8.084a2.25 2.25 0 01-2.244-2.077L4.772 5.79m14.456 0a48.108 48.108 0 00-3.478-.397m-12 .562c.34-.059.68-.114 1.022-.165m0 0a48.11 48.11 0 013.478-.397m7.5 0v-.916c0-1.18-.91-2.164-2.09-2.201a51.964 51.964 0 00-3.32 0c-1.18.037-2.09 1.022-2.09 2.201v.916m7.5 0a48.667 48.667 0 00-7.5 0" />
                </svg>
                <svg onClick={() => fetchDepartemnetsData()} xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="w-6 h-6 ml-3">
                  <path fillRule="evenodd" d="M12 5.25c-1.213 0-2.415.046-3.605.135a3.256 3.256 0 00-3.01 3.01c-.044.583-.077 1.17-.1 1.759L6.97 8.47a.75.75 0 011.06 1.06l-3 3a.75.75 0 01-1.06 0l-3-3a.75.75 0 011.06-1.06l1.752 1.751c.023-.65.06-1.296.108-1.939A4.756 4.756 0 018.282 3.89a49.423 49.423 0 017.436 0 4.756 4.756 0 014.392 4.392c.017.224.032.447.046.672a.75.75 0 01-1.497.092 48.187 48.187 0 00-.044-.651 3.256 3.256 0 00-3.01-3.01A47.926 47.926 0 0012 5.25zm6.97 6.22a.75.75 0 011.06 0l3 3a.75.75 0 11-1.06 1.06l-1.752-1.751a49.25 49.25 0 01-.108 1.939 4.756 4.756 0 01-4.392 4.392 49.412 49.412 0 01-7.436 0 4.756 4.756 0 01-4.392-4.392 49.112 49.112 0 01-.046-.672.75.75 0 111.497-.092c.013.217.028.434.044.651a3.256 3.256 0 003.01 3.01 47.951 47.951 0 007.21 0 3.256 3.256 0 003.01-3.01c.044-.583.077-1.17.1-1.759L17.03 15.53a.75.75 0 11-1.06-1.06l3-3z" clipRule="evenodd" />
                </svg>
              </div>
              <GlobalFilter filter={globalFilter} setFilter={setGlobalFilter} />
            </div>
            <div className="mx-auto">
              <div className="mx-auto xl:mx-0">
                {/* Table Menu */}
                <div className="flex flex-row items-center justify-between mb-2 mt-2">
                  {/* Toggle Columns */}
                  <div>
                    <div onClick={() => setIsList(!isList)} className="w-45 p-2 shadow rounded bg-white text-sm font-medium leading-none text-gray-800 flex items-center justify-between cursor-pointer">
                      Columns Show/Hide
                      <div>
                        {isList ? (
                          <div>
                            <svg width={10} height={6} viewBox="0 0 10 6" fill="none" xmlns="http://www.w3.org/2000/svg">
                              <path d="M5.00016 0.666664L9.66683 5.33333L0.333496 5.33333L5.00016 0.666664Z" fill="#1F2937" />
                            </svg>
                          </div>
                        ) : (
                          <div>
                            <svg width={10} height={6} viewBox="0 0 10 6" fill="none" xmlns="http://www.w3.org/2000/svg">
                              <path d="M5.00016 5.33333L0.333496 0.666664H9.66683L5.00016 5.33333Z" fill="#1F2937" />
                            </svg>
                          </div>
                        )}
                      </div>
                    </div>
                    {isList && (
                      <div className="w-40 mt-2 p-4 bg-white shadow rounded">
                        {/* element */}
                        {
                        
                          allColumns.map(column => (
                            <div key={column.id}>
                              <div className="flex items-center justify-between">
                                <div className="flex items-center">
                                  <div className="pl-4 flex items-center">
                                    <div className="bg-gray-100 rounded-sm border-gray-200 w-3 h-3 flex flex-shrink-0 justify-center items-center relative">
                                      <input type="checkbox" {...column.getToggleHiddenProps()} className="checkbox opacity-0 absolute cursor-pointer w-full h-full" />
                                      <div className="check-icon hidden bg-indigo-700 text-white rounded-sm">
                                        <svg className="icon icon-tabler icon-tabler-check" xmlns="http://www.w3.org/2000/svg" width={12} height={12} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round">
                                          <path stroke="none" d="M0 0h24v24H0z" />
                                          <path d="M5 12l5 5l10 -10" />
                                        </svg>
                                      </div>
                                    </div>
                                    <p className="text-sm leading-normal ml-2 text-gray-800">{String(column.Header)}</p>
                                  </div>
                                </div>
                              </div>
                            </div>
                          ))
                        }
                        <div className="flex items-center justify-between">
                          <div className="flex items-center">
                            <div className="pl-4 flex items-center">
                              <div className="bg-gray-100  rounded-sm border-gray-200  w-3 h-3 flex flex-shrink-0 justify-center items-center relative">
                                <input type="checkbox" {...getToggleHideAllColumnsProps()} className="checkbox opacity-0 absolute cursor-pointer w-full h-full" />
                                <div className="check-icon hidden bg-indigo-700 text-white rounded-sm">
                                  <svg className="icon icon-tabler icon-tabler-check" xmlns="http://www.w3.org/2000/svg" width={12} height={12} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round">
                                    <path stroke="none" d="M0 0h24v24H0z" />
                                    <path d="M5 12l5 5l10 -10" />
                                  </svg>
                                </div>
                              </div>
                              <p className="text-sm leading-normal ml-2 text-gray-800">Toggle All</p>
                            </div>
                          </div>
                        </div>                                            {/* element */}
                      </div>
                    )}
                    <style>
                      {` .checkbox:checked + .check-icon {display: flex;}`}
                    </style>
                  </div>
                  {/* Toggle Columns */}

                  {/* show elements */}
                  <select value={pageSize} onChange={e => setPageSize(Number(e.target.value))}>
                    {[10, 20, 30, 40, 50].map(pageSize => (
                      <option key={pageSize} value={pageSize}>
                        Show {pageSize} elements
                      </option>))}
                  </select>
                  {/* show elements */}
                  {/* ColumnOrder */}
                  <select onChange={e => changeOrdre(e.target.value)}>
                    <option defaultChecked key="default" value="default">Order By</option>
                    <option key="Name" value="email">Departement Name</option>
                  </select>
                  {/* ColumnOrder */}
                </div>
                {/* Table Menu */}
                <div className="flex justify-between border-t border-gray-300 bg-white my-0">
                  {/* Pagination */}
                  <div className="flex items-center lg:py-0 lg:px-6">
                    <p className="text-gray-600 text-xs">
                      Viewing {pageIndex + 1} - {pageIndex + 1} of {pageOptions.length}
                    </p>
                    <button onClick={() => previousPage()} disabled={!canPreviousPage}>
                      <a className="text-gray-600 ml-2 border-transparent border cursor-pointer rounded">
                        <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-chevron-left" width={20} height={20} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round">
                          <path stroke="none" d="M0 0h24v24H0z" />
                          <polyline points="15 6 9 12 15 18" />
                        </svg>
                      </a>
                    </button>
                    <button onClick={() => nextPage()} disabled={!canNextPage}>
                      <a className="text-gray-600 border-transparent border rounded focus:outline-none cursor-pointer">
                        <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-chevron-right" width={20} height={20} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round">
                          <path stroke="none" d="M0 0h24v24H0z" />
                          <polyline points="9 6 15 12 9 18" />
                        </svg>
                      </a>
                    </button>
                  </div>
                  {/* Pagination */}
                  {/* Go to page */}
                  <div className="flex flex-row items-center text-xs">
                    <div>
                      Go to page {' '}
                    </div>
                    <input type="number" value={pageIndex + 1}
                      onChange={e => {
                        const pageNumber = e.target.value ? Number(e.target.value) - 1 : 0;
                        gotoPage(pageNumber)
                      }}
                      className="ml-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 bg-white font-normal w-14 text-center h-7 flex items-center pl-3 text-sm border-gray-300 rounded border shadow" />
                  </div>
                  {/* Go to page */}
                  {/* Page number */}
                  <div className="flex items-center text-xs">
                    Page{' '}
                    <strong>
                      {pageIndex + 1} of {pageOptions.length}
                    </strong>{' '}
                  </div>
                  {/* Page number */}
                </div>
                {/*table*/}
                <div>
                  <div className="mx-auto container bg-white shadow rounded">
                    <div className="w-full overflow-y-auto">
                      <table {...getTableProps()} className="min-w-full bg-white">
                        <thead>
                          {headerGroups.map(headerGroup => (
                            <tr {...headerGroup.getHeaderGroupProps()} className="w-full h-16 border-gray-300 border-b py-8">
                              {headerGroup.headers.map((column) => (
                                <th {...column.getHeaderProps(column.getSortByToggleProps())} className="text-base font-bold text-center bg-indigo-700 text-white pr-6 tracking-normal leading-4">
                                  {column.render('Header')}
                                  <span>{column.isSorted ? (column.isSortedDesc ? ' 🔽' : ' 🔼') : ''}</span>
                                  {/* <div className="flex justify-center pt-1">{column.canFilter ? column.render('Filter') : null}</div> */}
                                </th>
                              ))}
                            </tr>
                          ))}
                        </thead>
                        <tbody {...getTableBodyProps()}>
                          {!isLoading ? (
                            <>
                              {
                                page.map(row => {
                                  prepareRow(row)
                                  return (
                                    <tr {...row.getRowProps()} className="h-24 text-center border-gray-300 border-b">
                                      {row.cells.map(cell => (
                                        <td {...cell.getCellProps()} className="text-sm pr-6 whitespace-no-wrap text-gray-800 tracking-normal leading-4">
                                          {
                                            cell.render('Cell')
                                          }
                                        </td>
                                      ))}
                                    </tr>
                                  )
                                })
                              }
                            </>
                          ) : (
                              <div>is Loading.....</div>
                          )}
                        </tbody>
                      </table>
                    </div>
                  </div>
                </div>
                {/*table*/}


                {/* Table Menu Footer*/}
                <div className="flex flex-row items-center justify-between">
                  {/* Pagination */}
                  <div className="flex items-center py-3 lg:py-0 lg:px-6">
                    <p className="text-base text-gray-600">
                      Viewing {pageIndex + 1} - {pageIndex + 1} of {pageOptions.length}
                    </p>
                    <button onClick={() => previousPage()} disabled={!canPreviousPage}>
                      <a className="text-gray-600 ml-2 border-transparent border cursor-pointer rounded">
                        <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-chevron-left" width={20} height={20} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round">
                          <path stroke="none" d="M0 0h24v24H0z" />
                          <polyline points="15 6 9 12 15 18" />
                        </svg>
                      </a>
                    </button>
                    <button onClick={() => nextPage()} disabled={!canNextPage}>
                      <a className="text-gray-600 border-transparent border rounded focus:outline-none cursor-pointer">
                        <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-chevron-right" width={20} height={20} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round">
                          <path stroke="none" d="M0 0h24v24H0z" />
                          <polyline points="9 6 15 12 9 18" />
                        </svg>
                      </a>
                    </button>
                  </div>
                  {/* Pagination */}
                  {/* Go to page */}
                  <div className="flex flex-row items-center">
                    <div>
                      Go to page {' '}
                    </div>
                    <input type="number" value={pageIndex + 1}
                      onChange={e => {
                        const pageNumber = e.target.value ? Number(e.target.value) - 1 : 0;
                        gotoPage(pageNumber)
                      }}
                      className="ml-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 bg-white font-normal w-14 text-center h-10 flex items-center pl-3 text-sm border-gray-300 rounded border shadow" />
                  </div>
                  {/* Go to page */}
                  {/* Page number */}
                  <div>
                    Page{' '}
                    <strong>
                      {pageIndex + 1} of {pageOptions.length}
                    </strong>{' '}
                  </div>
                  {/* Page number */}
                </div>
                {/* Table Menu Footer */}
              </div>
            </div>
          </div>
        </div>
      </div>

      {showDoctorsList &&
        < div id="Add" className="z-50 fixed w-full flex justify-center inset-0">
          <div className="w-full h-full bg-gray-500 bg-opacity-75 transition-opacity z-0 absolute inset-0" />
          <div className="mx-auto container">
            <div className="flex items-center justify-center h-full w-full">
              <div className="bg-white rounded-md shadow fixed overflow-y-auto sm:h-auto w-10/12 md:w-8/12 lg:w-1/2 2xl:w-2/5">
                <div className="bg-gray-100 rounded-tl-md rounded-tr-md px-4 md:px-8 md:py-4 py-7 flex items-center justify-between">
                  <p className="text-base font-semibold text-center">Doctors</p>
                  <button className="focus:outline-none">
                    <svg onClick={() => setshowDoctorsList(!showDoctorsList)} width={20} height={20} viewBox="0 0 28 28" fill="none" xmlns="http://www.w3.org/2000/svg">
                      <path d="M21 7L7 21" stroke="#A1A1AA" strokeWidth="1.75" strokeLinecap="round" strokeLinejoin="round" />
                      <path d="M7 7L21 21" stroke="#A1A1AA" strokeWidth="1.75" strokeLinecap="round" strokeLinejoin="round" />
                    </svg>
                  </button>
                </div>
                <div className="px-4 md:px-10 pt-6 md:pt-12 md:pb-4 pb-7">
                  <form>
                    <div className="flex-row text-center mb-6">
                        {doctorsList.map(d =>
                        {
                            return (
                              <>
                                <p key={d.doctorId}>{d.fisrtName} {d.lastName} / {d.specialty} / {d.phone} / {d.email}</p>
                                <br />
                              </>
                            )                          
                        })
                        }
                    </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      }
    </>
  );
}