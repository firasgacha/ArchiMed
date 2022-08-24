import React, { useEffect, useMemo, useState } from "react";
import { useTable, useSortBy, useGlobalFilter, useFilters, usePagination } from "react-table";
import MOCK_DATA from "./MOCK_DATA.json";
import GlobalFilter from "../../components/GlobalFilter";
import ColumnFilter from "components/ColumnFilter";

export default function ListOfPatients() {
    const COLUMNS = [
        {
            Header: 'Id',
            Footer: 'Id',
            accessor: 'MedecinId',
            Filter: ColumnFilter
        },

        {
            Header: 'First Name',
            Footer: 'First Name',
            accessor: 'first_name',
            Filter: ColumnFilter
        },
        {
            Header: 'Last Name',
            Footer: 'Last Name',
            accessor: 'last_name',
            Filter: ColumnFilter
        },
        {
            Header: 'CIN',
            Footer: 'CIN',
            accessor: 'CIN',
            Filter: ColumnFilter
        },
        {
            Header: 'Email',
            Footer: 'Email',
            accessor: 'email',
            Filter: ColumnFilter
        },
        {
            Header: 'Address',
            accessor: 'adresse',
        },
        {
            Header: 'City',
            accessor: 'City',
        },
        {
            Header: 'Country',
            accessor: 'Country',
        },
        {
            Header: 'Postal_Code',
            accessor: 'Postal_Code',
        },
        {
            Header: 'Birthday',
            accessor: 'Birthday',
        },
        {
            Header: 'Phone',
            accessor: 'Phone',
        },
        {
            Header: 'ProfileUrl',
            accessor: 'ProfileUrl'
        },
        {
            Header: 'ProfileImage',
            accessor: 'ProfileImage'
        }
    ]

    const columns = useMemo(() => COLUMNS, []);
    const data = useMemo(() => MOCK_DATA, []);

    const { getTableProps, getTableBodyProps, headerGroups, footerGroups, page, nextPage, previousPage, setPageSize, canNextPage, canPreviousPage, pageOptions, gotoPage, pageCount, prepareRow, state, setGlobalFilter } = useTable({
        columns,
        data,
        initialState: { pageIndex: 0, pageSize: 50 }
    },
        useFilters,
        useGlobalFilter,
        useSortBy,
        usePagination);

    const { pageIndex, pageSize } = state;

    const { globalFilter } = state;
    return (

        <>
            <div id="login">
                <div className="bg-white p-10 2xl:p-5">
                    <div className="container mx-auto bg-white rounded">
                        <div className="xl:w-full border-b border-gray-300 py-5 bg-white">
                            <div className="flex w-11/12 mx-auto xl:w-full xl:mx-0 items-center">
                                <p className="text-lg text-gray-800 font-bold">List of patients</p>
                                <div className="ml-2 cursor-pointer text-gray-600 ">
                                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width={16} height={16}>
                                        <path className="heroicon-ui" d="M12 22a10 10 0 1 1 0-20 10 10 0 0 1 0 20zm0-2a8 8 0 1 0 0-16 8 8 0 0 0 0 16zm0-9a1 1 0 0 1 1 1v4a1 1 0 0 1-2 0v-4a1 1 0 0 1 1-1zm0-4a1 1 0 1 1 0 2 1 1 0 0 1 0-2z" fill="currentColor" />
                                    </svg>
                                </div>
                            </div>
                        </div>
                        <div className="mx-auto">
                            <div className="xl:w-9/12 w-11/12 mx-auto xl:mx-0">
                                {/*Content*/}

                                <div className="py-20">
                                    <div className="mx-auto container bg-white dark:bg-gray-800 shadow rounded">
                                        <div className="w-full overflow-x-scroll xl:overflow-x-hidden">
                                            <table {...getTableProps()} className="min-w-full bg-white dark:bg-gray-800">
                                                <thead>
                                                    <tr className="w-full h-16 border-gray-300 dark:border-gray-200 border-b py-8">
                                                        {/* <th className="pl-8 text-gray-600 dark:text-gray-400 font-normal pr-6 text-left text-sm tracking-normal leading-4">
                                                            <input type="checkbox" className="cursor-pointer relative w-5 h-5 border rounded border-gray-400 dark:border-gray-200 bg-white dark:bg-gray-800 outline-none" />
                                                        </th> */}
                                                        
                                                        <th className="text-gray-600 dark:text-gray-400 font-normal pr-6 text-left text-sm tracking-normal leading-4">Invoice Number</th>
                                                    
                                                        {/* <th className="text-gray-600 dark:text-gray-400 font-normal pr-6 text-left text-sm tracking-normal leading-4">
                                                            <div className="opacity-0 w-2 h-2 rounded-full bg-indigo-400" />
                                                        </th> */}
                                                        {/* <td className="text-gray-600 dark:text-gray-400 font-normal pr-8 text-left text-sm tracking-normal leading-4">More</td> */}
                                                    </tr>
                                                    
                                                </thead>
                                                <tbody>
                                                    <tr className="h-24 border-gray-300 dark:border-gray-200 border-b">
                                                        <td className="pl-8 pr-6 text-left whitespace-no-wrap text-sm text-gray-800 dark:text-gray-100 tracking-normal leading-4">
                                                            <input type="checkbox" className="cursor-pointer relative w-5 h-5 border rounded border-gray-400 dark:border-gray-200 bg-white dark:bg-gray-800 outline-none" />
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">
                                                            <div className="relative w-10 text-gray-600 dark:text-gray-400">
                                                                <div className="absolute top-0 right-0 w-5 h-5 mr-2 -mt-1 rounded-full bg-indigo-700 text-white flex justify-center items-center text-xs">3</div>
                                                                <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-file" width={28} height={28} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round">
                                                                    <path stroke="none" d="M0 0h24v24H0z" />
                                                                    <path d="M14 3v4a1 1 0 0 0 1 1h4" />
                                                                    <path d="M17 21h-10a2 2 0 0 1 -2 -2v-14a2 2 0 0 1 2 -2h7l5 5v11a2 2 0 0 1 -2 2z" />
                                                                </svg>
                                                            </div>
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">#MC10023</td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">Toyota Motors</td>
                                                        <td className="pr-6 whitespace-no-wrap">
                                                            <div className="flex items-center">
                                                                <div className="h-8 w-8">
                                                                    <img src="https://tuk-cdn.s3.amazonaws.com/assets/components/advance_tables/at_1.png" alt='true' className="h-full w-full rounded-full overflow-hidden shadow" />
                                                                </div>
                                                                <p className="ml-2 text-gray-800 dark:text-gray-100 tracking-normal leading-4 text-sm">Carrie Anthony</p>
                                                            </div>
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">$2,500</td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">02.03.20</td>
                                                        <td className="pr-6">
                                                            <div className="w-2 h-2 rounded-full bg-indigo-400" />
                                                        </td>
                                                        <td className="pr-8 relative">
                                                            <div className="dropdown-content mt-8 absolute left-0 -ml-12 shadow-md z-10 hidden w-32">
                                                                <ul className="bg-white dark:bg-gray-800 shadow rounded py-1">
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Edit</li>
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Delete</li>
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Duplicate</li>
                                                                </ul>
                                                            </div>
                                                            <button className="text-gray-500 rounded cursor-pointer border border-transparent focus:outline-none">
                                                                <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-dots-vertical dropbtn" width={28} height={28} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round">
                                                                    <path stroke="none" d="M0 0h24v24H0z" />
                                                                    <circle cx={12} cy={12} r={1} />
                                                                    <circle cx={12} cy={19} r={1} />
                                                                    <circle cx={12} cy={5} r={1} />
                                                                </svg>
                                                            </button>
                                                        </td>
                                                    </tr>
                                                    <tr className="h-24 border-gray-300 dark:border-gray-200 border-b">
                                                        <td className="pl-8 pr-6 text-left whitespace-no-wrap text-sm text-gray-800 dark:text-gray-100 tracking-normal leading-4">
                                                            <input type="checkbox" className="cursor-pointer relative w-5 h-5 border rounded border-gray-400 dark:border-gray-200 bg-white dark:bg-gray-800 outline-none" />
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">
                                                            <div className="text-gray-400 relative w-10">
                                                                <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-file" width={28} height={28} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round">
                                                                    <path stroke="none" d="M0 0h24v24H0z" />
                                                                    <path d="M14 3v4a1 1 0 0 0 1 1h4" />
                                                                    <path d="M17 21h-10a2 2 0 0 1 -2 -2v-14a2 2 0 0 1 2 -2h7l5 5v11a2 2 0 0 1 -2 2z" />
                                                                </svg>
                                                            </div>
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">#MC10023</td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">Toyota Motors</td>
                                                        <td className="pr-6 whitespace-no-wrap">
                                                            <div className="flex items-center">
                                                                <div className="h-8 w-8">
                                                                    <img src="https://tuk-cdn.s3.amazonaws.com/assets/components/advance_tables/at_2.png" alt='true' className="h-full w-full rounded-full overflow-hidden shadow" />
                                                                </div>
                                                                <p className="ml-2 text-gray-800 dark:text-gray-100 tracking-normal leading-4 text-sm">Carrie Anthony</p>
                                                            </div>
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">$2,500</td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">02.03.20</td>
                                                        <td className="pr-6">
                                                            <div className="w-2 h-2 rounded-full bg-red-400" />
                                                        </td>
                                                        <td className="pr-8 relative">
                                                            <button className="text-gray-500 rounded cursor-pointer border border-transparent focus:outline-none ">
                                                                <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-dots-vertical dropbtn" width={28} height={28} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round" >
                                                                    <path stroke="none" d="M0 0h24v24H0z" />
                                                                    <circle cx={12} cy={12} r={1} />
                                                                    <circle cx={12} cy={19} r={1} />
                                                                    <circle cx={12} cy={5} r={1} />
                                                                </svg>
                                                            </button>
                                                            <div className="dropdown-content mt-1 absolute left-0 -ml-12 shadow-md z-10 hidden w-32">
                                                                <ul className="bg-white dark:bg-gray-800 shadow rounded py-1">
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Edit</li>
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Delete</li>
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Duplicate</li>
                                                                </ul>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr className="h-24 border-gray-300 dark:border-gray-200 border-b">
                                                        <td className="pl-8 pr-6 text-left whitespace-no-wrap text-sm text-gray-800 dark:text-gray-100 tracking-normal leading-4">
                                                            <input type="checkbox" className="cursor-pointer relative w-5 h-5 border rounded border-gray-400 dark:border-gray-200 bg-white dark:bg-gray-800 outline-none" />
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">
                                                            <div className="text-gray-400 relative w-10">
                                                                <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-file" width={28} height={28} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round">
                                                                    <path stroke="none" d="M0 0h24v24H0z" />
                                                                    <path d="M14 3v4a1 1 0 0 0 1 1h4" />
                                                                    <path d="M17 21h-10a2 2 0 0 1 -2 -2v-14a2 2 0 0 1 2 -2h7l5 5v11a2 2 0 0 1 -2 2z" />
                                                                </svg>
                                                            </div>
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">#MC10023</td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">Toyota Motors</td>
                                                        <td className="pr-6 whitespace-no-wrap">
                                                            <div className="flex items-center">
                                                                <div className="h-8 w-8">
                                                                    <img src="https://tuk-cdn.s3.amazonaws.com/assets/components/advance_tables/at_3.png" alt='true' className="h-full w-full rounded-full overflow-hidden shadow" />
                                                                </div>
                                                                <p className="ml-2 text-gray-800 dark:text-gray-100 tracking-normal leading-4 text-sm">Carrie Anthony</p>
                                                            </div>
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">$2,500</td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">02.03.20</td>
                                                        <td className="pr-6">
                                                            <div className="w-2 h-2 rounded-full bg-indigo-400" />
                                                        </td>
                                                        <td className="pr-8 relative">
                                                            <button className="text-gray-500 rounded cursor-pointer border border-transparent focus:outline-none">
                                                                <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-dots-vertical dropbtn" width={28} height={28} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round" >
                                                                    <path stroke="none" d="M0 0h24v24H0z" />
                                                                    <circle cx={12} cy={12} r={1} />
                                                                    <circle cx={12} cy={19} r={1} />
                                                                    <circle cx={12} cy={5} r={1} />
                                                                </svg>
                                                            </button>
                                                            <div className="dropdown-content mt-1 absolute left-0 -ml-12 shadow-md z-10 hidden w-32">
                                                                <ul className="bg-white dark:bg-gray-800 shadow rounded py-1">
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Edit</li>
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Delete</li>
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Duplicate</li>
                                                                </ul>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr className="h-24 border-gray-300 dark:border-gray-200 border-b">
                                                        <td className="pl-8 pr-6 text-left whitespace-no-wrap text-sm text-gray-800 dark:text-gray-100 tracking-normal leading-4">
                                                            <input type="checkbox" className="cursor-pointer relative w-5 h-5 border rounded border-gray-400 dark:border-gray-200 bg-white dark:bg-gray-800 outline-none" />
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">
                                                            <div className="text-gray-400 relative w-10">
                                                                <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-file" width={28} height={28} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round">
                                                                    <path stroke="none" d="M0 0h24v24H0z" />
                                                                    <path d="M14 3v4a1 1 0 0 0 1 1h4" />
                                                                    <path d="M17 21h-10a2 2 0 0 1 -2 -2v-14a2 2 0 0 1 2 -2h7l5 5v11a2 2 0 0 1 -2 2z" />
                                                                </svg>
                                                            </div>
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">#MC10023</td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">Toyota Motors</td>
                                                        <td className="pr-6 whitespace-no-wrap">
                                                            <div className="flex items-center">
                                                                <div className="h-8 w-8">
                                                                    <img src="https://tuk-cdn.s3.amazonaws.com/assets/components/advance_tables/at_1.png" alt='true' className="h-full w-full rounded-full overflow-hidden shadow" />
                                                                </div>
                                                                <p className="ml-2 text-gray-800 dark:text-gray-100 tracking-normal leading-4 text-sm">Carrie Anthony</p>
                                                            </div>
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">$2,500</td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">02.03.20</td>
                                                        <td className="pr-6">
                                                            <div className="w-2 h-2 rounded-full bg-indigo-400" />
                                                        </td>
                                                        <td className="pr-8 relative">
                                                            <button className="text-gray-500 rounded cursor-pointer border border-transparent focus:outline-none">
                                                                <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-dots-vertical dropbtn" width={28} height={28} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round" >
                                                                    <path stroke="none" d="M0 0h24v24H0z" />
                                                                    <circle cx={12} cy={12} r={1} />
                                                                    <circle cx={12} cy={19} r={1} />
                                                                    <circle cx={12} cy={5} r={1} />
                                                                </svg>
                                                            </button>
                                                            <div className="dropdown-content mt-1 absolute left-0 -ml-12 shadow-md z-10 hidden w-32">
                                                                <ul className="bg-white dark:bg-gray-800 shadow rounded py-1">
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Edit</li>
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Delete</li>
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Duplicate</li>
                                                                </ul>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr className="h-24 border-gray-300 dark:border-gray-200 border-b">
                                                        <td className="pl-8 pr-6 text-left whitespace-no-wrap text-sm text-gray-800 dark:text-gray-100 tracking-normal leading-4">
                                                            <input type="checkbox" className="cursor-pointer relative w-5 h-5 border rounded border-gray-400 dark:border-gray-200 bg-white dark:bg-gray-800 outline-none" />
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">
                                                            <div className="relative w-10">
                                                                <div className="absolute top-0 right-0 w-5 h-5 mr-2 -mt-1 rounded-full bg-indigo-700 text-white flex justify-center items-center text-xs">1</div>
                                                                <div className="text-gray-600 dark:text-gray-400">
                                                                    <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-file" width={28} height={28} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round">
                                                                        <path stroke="none" d="M0 0h24v24H0z" />
                                                                        <path d="M14 3v4a1 1 0 0 0 1 1h4" />
                                                                        <path d="M17 21h-10a2 2 0 0 1 -2 -2v-14a2 2 0 0 1 2 -2h7l5 5v11a2 2 0 0 1 -2 2z" />
                                                                    </svg>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">#MC10023</td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">Toyota Motors</td>
                                                        <td className="pr-6 whitespace-no-wrap">
                                                            <div className="flex items-center">
                                                                <div className="h-8 w-8">
                                                                    <img src="https://tuk-cdn.s3.amazonaws.com/assets/components/advance_tables/at_2.png" alt='true' className="h-full w-full rounded-full overflow-hidden shadow" />
                                                                </div>
                                                                <p className="ml-2 text-gray-800 dark:text-gray-100 tracking-normal leading-4 text-sm">Carrie Anthony</p>
                                                            </div>
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">$2,500</td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">02.03.20</td>
                                                        <td className="pr-6">
                                                            <div className="w-2 h-2 rounded-full bg-red-400" />
                                                        </td>
                                                        <td className="pr-8 relative">
                                                            <button className="text-gray-500 rounded cursor-pointer border border-transparent focus:outline-none">
                                                                <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-dots-vertical dropbtn" width={28} height={28} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round" >
                                                                    <path stroke="none" d="M0 0h24v24H0z" />
                                                                    <circle cx={12} cy={12} r={1} />
                                                                    <circle cx={12} cy={19} r={1} />
                                                                    <circle cx={12} cy={5} r={1} />
                                                                </svg>
                                                            </button>
                                                            <div className="dropdown-content mt-1 absolute left-0 -ml-12 shadow-md z-10 hidden w-32">
                                                                <ul className="bg-white dark:bg-gray-800 shadow rounded py-1">
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Edit</li>
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Delete</li>
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Duplicate</li>
                                                                </ul>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr className="h-24 border-gray-300 dark:border-gray-200 border-b">
                                                        <td className="pl-8 pr-6 text-left whitespace-no-wrap text-sm text-gray-800 dark:text-gray-100 tracking-normal leading-4">
                                                            <input type="checkbox" className="cursor-pointer relative w-5 h-5 border rounded border-gray-400 dark:border-gray-200 bg-white dark:bg-gray-800 outline-none" />
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">
                                                            <div className="relative w-10">
                                                                <div className="absolute top-0 right-0 w-5 h-5 mr-2 -mt-1 rounded-full bg-indigo-700 text-white flex justify-center items-center text-xs">5</div>
                                                                <div className="text-gray-600 dark:text-gray-400">
                                                                    <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-file" width={28} height={28} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round">
                                                                        <path stroke="none" d="M0 0h24v24H0z" />
                                                                        <path d="M14 3v4a1 1 0 0 0 1 1h4" />
                                                                        <path d="M17 21h-10a2 2 0 0 1 -2 -2v-14a2 2 0 0 1 2 -2h7l5 5v11a2 2 0 0 1 -2 2z" />
                                                                    </svg>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">#MC10023</td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">Toyota Motors</td>
                                                        <td className="pr-6 whitespace-no-wrap">
                                                            <div className="flex items-center">
                                                                <div className="h-8 w-8">
                                                                    <img src="https://tuk-cdn.s3.amazonaws.com/assets/components/advance_tables/at_3.png" alt='true' className="h-full w-full rounded-full overflow-hidden shadow" />
                                                                </div>
                                                                <p className="ml-2 text-gray-800 dark:text-gray-100 tracking-normal leading-4 text-sm">Carrie Anthony</p>
                                                            </div>
                                                        </td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">$2,500</td>
                                                        <td className="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">02.03.20</td>
                                                        <td className="pr-6">
                                                            <div className="w-2 h-2 rounded-full bg-gray-600" />
                                                        </td>
                                                        <td className="pr-8 relative">
                                                            <button className="text-gray-500 rounded cursor-pointer border border-transparent focus:outline-none">
                                                                <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-dots-vertical dropbtn" width={28} height={28} viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" fill="none" strokeLinecap="round" strokeLinejoin="round" >
                                                                    <path stroke="none" d="M0 0h24v24H0z" />
                                                                    <circle cx={12} cy={12} r={1} />
                                                                    <circle cx={12} cy={19} r={1} />
                                                                    <circle cx={12} cy={5} r={1} />
                                                                </svg>
                                                            </button>
                                                            <div className="dropdown-content mt-1 absolute left-0 -ml-12 shadow-md z-10 hidden w-32">
                                                                <ul className="bg-white dark:bg-gray-800 shadow rounded py-1">
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Edit</li>
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Delete</li>
                                                                    <li className="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">Duplicate</li>
                                                                </ul>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                {/*Content*/}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}