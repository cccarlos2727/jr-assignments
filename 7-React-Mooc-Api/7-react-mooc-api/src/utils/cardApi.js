import axios from 'axios';
import React from 'react'

const fetchData = async (dataApi) => {
  try {
    const response = await axios.get(dataApi);
    const data = response.data;
    return data;
  } catch(error) {
    console.error("Error: ",error)
  }
  
}

export default fetchData