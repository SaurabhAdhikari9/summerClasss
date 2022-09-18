import axios from 'axios';
export default axios.create({
    baseURL:"https://localhost:44397/api/",
    // baseURL:"https://littletandart24.conveyor.cloud/api/",
    // baseURL:"https://192.168.1.65:45455/api/",
    // https://192.168.1.65:45455/
    headers:{
        "Content-type":"application/json"
    }
})