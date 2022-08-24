import React, { useEffect, useMemo, useState } from "react";
import { useTable, useSortBy, useGlobalFilter, useFilters, usePagination, useColumnOrder } from "react-table";
import MOCK_DATA from "./MOCK_DATA.json";
import GlobalFilter from "../../components/GlobalFilter";
import ColumnFilter from "components/ColumnFilter";
import axios from "axios";
import { format } from 'date-fns';

export default function ListOfDoctors() {
    const COLUMNS = [
        {
            Header: 'First Name',
            Footer: 'First Name',
            accessor: 'nom',
            Filter: ColumnFilter
        },
        {
            Header: 'Last Name',
            Footer: 'Last Name',
            accessor: 'prenom',
            Filter: ColumnFilter
        },
        {
            Header: 'CIN',
            Footer: 'CIN',
            accessor: 'cin',
            Filter: ColumnFilter
        },
        {
            Header: 'Birthday',
            Footer: 'Birthday',
            accessor: 'naissance',
            Filter: ColumnFilter,
            // Cell: (value: Date) => { return format(new Date(value), 'dd/MM/yyyy')}
        },
        {
            Header: 'Email',
            Footer: 'Email',
            accessor: 'email',
            Filter: ColumnFilter
        },
        {
            Header: 'Phone',
            Footer: 'Phone',
            accessor: 'telephone',
            Filter: ColumnFilter
        },
        {
            Header: 'Adresse',
            Footer: 'Adresse',
            accessor: 'adresse',
            Filter: ColumnFilter
        },
        {
            Header: 'Postal_Code',
            Footer: 'Postal_Code',
            accessor: 'zipcode',
            Filter: ColumnFilter
        },

        {
            Header: 'City',
            Footer: 'City',
            accessor: 'ville',
            Filter: ColumnFilter
        },
        {
            Header: 'Country',
            Footer: 'Country',
            accessor: 'pays',
            Filter: ColumnFilter
        },
        {
            Header: 'ProfileImage',
            Footer: 'ProfileImage',
            accessor: 'profileImage',
            Filter: ColumnFilter
        },
        {
            Header: 'ProfileUrl',
            Footer: 'ProfileUrl',
            accessor: 'profileUrl',  
            Filter: ColumnFilter
        }
    ]
    const [doctorsListData, setDoctorsListData] = useState([]);
    const columns = useMemo(() => COLUMNS, []);
    const data = useMemo(() => doctorsListData, []);


    const { allColumns, getToggleHideAllColumnsProps, getTableProps, getTableBodyProps, headerGroups, footerGroups, page, nextPage, previousPage, setPageSize, setColumnOrder, canNextPage, canPreviousPage, pageOptions, gotoPage, pageCount, prepareRow, state, setGlobalFilter } =
        useTable({
            columns,
            data,
            initialState: { pageIndex: 0, pageSize: 10 }
        },
            useColumnOrder,
            useFilters,
            useGlobalFilter,
            useSortBy,
            usePagination);

    const { pageIndex, pageSize } = state;

    const GetDoctorsData = () => {
        axios.get('Medecin')
            .then(response => {
                const result = response.data;
                setDoctorsListData(result);
                console.log('result', result);
            }).catch(err => { console.log(err) })
    }

    const { globalFilter } = state;

    const changeOrdre = (v: String) => {
        switch (v) {
            case "email": {
                setColumnOrder(['email', 'CIN', 'first_name', 'last_name', 'id']);
                break;
            }
            case "cin": {
                setColumnOrder(['CIN', 'email', 'first_name', 'last_name', 'id']);
                break;
            }
            case "default": {
                setColumnOrder(['id', 'first_name', 'last_name', 'CIN', 'email']);
                break;
            }
            default: {
                break;
            }
        }
    }
    const [isList, setIsList] = useState(false);
    const [isSubList, setIsSubList] = useState(3);

    useEffect(()=>{
        GetDoctorsData();
    },[])
    return (

        <div id="listOfDoctors">
            <div className="bg-white p-10 2xl:p-5">
                <div className="container mx-auto bg-white rounded">
                    <div className="flex justify-between border-b border-gray-300 py-5 bg-white">
                        <div className="flex mx-auto xl:w-full xl:mx-0 items-center">
                            <p className="text-lg text-gray-800 font-bold">List of doctors</p>
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
                                    <option key="email" value="email">Email</option>
                                    <option key="cin" value="cin">CIN</option>
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
                                            </tbody>
                                            <tfoot>
                                                {
                                                    footerGroups.map(footerGroups => (
                                                        <tr {...footerGroups.getFooterGroupProps()} className="w-full h-16 border-gray-300 border-b py-8">
                                                            {
                                                                footerGroups.headers.map(column => (
                                                                    <td {...column.getFooterGroupProps} className="text-base font-bold text-center bg-indigo-700 text-white pr-6 tracking-normal leading-4">
                                                                        {column.render('Footer')}
                                                                        <span>{column.isSorted ? (column.isSortedDesc ? ' 🔽' : ' 🔼') : ''}</span>
                                                                        {/* <div className="flex justify-center pt-1">{column.canFilter ? column.render('Filter') : null}</div> */}
                                                                    </td>
                                                                ))
                                                            }
                                                        </tr>
                                                    ))
                                                }
                                            </tfoot>
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
    );
}