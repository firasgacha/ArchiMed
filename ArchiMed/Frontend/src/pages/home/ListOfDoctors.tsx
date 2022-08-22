import React, { useEffect, useMemo, useState } from "react";
import { useTable, useSortBy, useGlobalFilter, useFilters, usePagination } from "react-table";
import MOCK_DATA from "./MOCK_DATA.json";
import GlobalFilter from "../../components/GlobalFilter";
import ColumnFilter from "components/ColumnFilter";
export default function ListOfDoctors() {
    const COLUMNS = [
        {
            Header: 'Id',
            accessor: 'MedecinId',
            Filter: ColumnFilter
        },
        {
            Header: 'First Name',
            accessor: 'first_name',
            Filter: ColumnFilter
        },
        {
            Header: 'Last Name',
            accessor: 'last_name',
            Filter: ColumnFilter
        },
        {
            Header: 'CIN',
            accessor: 'CIN',
            Filter: ColumnFilter
        },
        // {
        //     Header: 'Address',
        //     accessor: 'adresse'
        // },
        // {
        //     Header: 'City',
        //     accessor: 'ville'
        // },
        // {
        //     Header: 'Country',
        //     accessor: 'pays'
        // },
        // {
        //     Header: 'Zip Code',
        //     accessor: 'zipcode'
        // },
        {
            Header: 'Email',
            accessor: 'email',
            Filter: ColumnFilter
        },
        // {
        //     Header: 'Birthday',
        //     accessor: 'Birthday'
        // }
        // {
        //     Header: 'Phone',
        //     accessor: 'telephone'
        // },
        // {
        //     Header: 'ProfileUrl',
        //     accessor: 'ProfileUrl'
        // },
        // {
        //     Header: 'ProfilePicture',
        //     accessor: 'ProfileImage'
        // }
    ]
    // const [DoctorList, setDoctorList] = useState([]);



    const columns = useMemo(() => COLUMNS, []);
    const data = useMemo(() => MOCK_DATA, []);


    const { getTableProps, getTableBodyProps, headerGroups, page, nextPage, previousPage, setPageSize, canNextPage, canPreviousPage, pageOptions, gotoPage, pageCount, prepareRow, state, setGlobalFilter } = useTable({
        columns,
        data,
        initialState: { pageIndex: 0, pageSize: 50 }
    },
        useFilters,
        useGlobalFilter,
        useSortBy,
        usePagination);

    const { pageIndex, pageSize } = state;

    // const GetDoctorsData = () => {
    //     fetch('https://localhost:7058/api/Medecin',{
    //         method: 'GET',
    //         headers: {
    //             'accept': 'text/plain'
    //         }
    //     })
    //         .then(response => {
    //             const result = response;
    //             console.log('result', result);
    //         }).catch(err => { console.log(err) })
    // }

    const { globalFilter } = state;


    return (
        <div id="login">
            <div className="bg-white p-10 2xl:p-5">
                <div className="container mx-auto bg-white rounded">
                    <div className="xl:w-full border-b border-gray-300 py-5 bg-white">
                        <div className="flex w-11/12 mx-auto xl:w-full xl:mx-0 items-center">
                            <p className="text-lg text-gray-800 font-bold">List of doctors</p>
                            <div className="ml-2 cursor-pointer text-gray-600 ">
                                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width={16} height={16}>
                                    <path className="heroicon-ui" d="M12 22a10 10 0 1 1 0-20 10 10 0 0 1 0 20zm0-2a8 8 0 1 0 0-16 8 8 0 0 0 0 16zm0-9a1 1 0 0 1 1 1v4a1 1 0 0 1-2 0v-4a1 1 0 0 1 1-1zm0-4a1 1 0 1 1 0 2 1 1 0 0 1 0-2z" fill="currentColor" />
                                </svg>
                            </div>
                        </div>
                    </div>
                    <div className="mx-auto">
                        <div className="xl:w-9/12 w-11/12 mx-auto xl:mx-0">
                            {/*table*/}
                            <GlobalFilter filter={globalFilter} setFilter={setGlobalFilter} />
                            <table {...getTableProps()}>
                                <thead>
                                    {headerGroups.map(headerGroup => (
                                        <tr {...headerGroup.getHeaderGroupProps()}>
                                            {headerGroup.headers.map((column) => (
                                                <th {...column.getHeaderProps(column.getSortByToggleProps())}>
                                                    {column.render('Header')}
                                                    <span>{column.isSorted ? (column.isSortedDesc ? ' 🔽' : ' 🔼') : ''}</span>
                                                    <div>{column.canFilter ? column.render('Filter') : null}</div>
                                                </th>
                                            ))}
                                        </tr>
                                    ))}
                                    <tr>
                                        <th>

                                        </th>
                                    </tr>
                                </thead>
                                <tbody {...getTableBodyProps()}>
                                    {
                                        page.map(row => {
                                            prepareRow(row)
                                            return (
                                                <tr {...row.getRowProps()}>
                                                    {row.cells.map(cell => (
                                                        <td {...cell.getCellProps()}>
                                                            {cell.render('Cell')}
                                                        </td>
                                                    ))}
                                                </tr>
                                            )
                                        })
                                    }
                                </tbody>
                            </table>
                            {/*table*/}
                            <div>
                                <span>
                                    Page{' '}
                                    <strong>
                                        {pageIndex + 1} of {pageOptions.length}
                                    </strong>{' '}
                                </span>
                                <span>
                                    | Go to page {' '}
                                    <input type="number" defaultValue={pageIndex + 1}
                                        onChange={e => {
                                            const pageNumber = e.target.value ? Number(e.target.value) - 1 : 0;
                                            gotoPage(pageNumber)
                                        }} />
                                </span>
                                <select value={pageSize} onChange={e => setPageSize(Number(e.target.value))}>
                                    {[10, 20, 30, 40, 50].map(pageSize => (
                                        <option key={pageSize} value={pageSize}>
                                            Show {pageSize}
                                        </option>))}
                                </select>
                                <button onClick={() => gotoPage(0)} disabled={!canPreviousPage}>{'<<'}</button>
                                <button onClick={() => previousPage()} disabled={!canPreviousPage}>Previous</button>
                                <button onClick={() => nextPage()} disabled={!canNextPage}>Next</button>
                                <button onClick={() => gotoPage(pageCount - 1)} disabled={!canNextPage}>{'>>'}</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}