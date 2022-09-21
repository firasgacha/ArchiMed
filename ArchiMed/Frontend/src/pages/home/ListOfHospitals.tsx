import axios from 'axios';
import React, { useState } from 'react';

import { CountryList } from '../../components/CountryListCode';

export default function ListOfHospitals() {
  return (
    <>
      {CountryList.length}
      <select name="specialite" id="specialite" className="w-3/4 focus:outline-none placeholder-gray-500 py-3 px-3 text-sm leading-none text-gray-800 bg-white border rounded border-gray-200">
        <option defaultChecked className="focus:outline-none placeholder-gray-500 py-3 px-3 text-sm leading-none text-gray-800 bg-white border rounded border-gray-200">Choose specialite</option>
        {CountryList.map((specialite) => (
          <option value={specialite.dial_code} className="w-1/2 focus:outline-none placeholder-gray-500 py-3 px-3 text-sm leading-none text-gray-800 bg-white border rounded border-gray-200">{specialite.name} / {specialite.dial_code}</option>
        ))}
      </select>
    </>
  )
}
