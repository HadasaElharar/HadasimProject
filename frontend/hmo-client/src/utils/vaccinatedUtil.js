import api from '../api';

const GetAllVaccinateds = async() => {
    return await api.get('Vaccinated').then(res => res.data);
}

const GetVaccinatedById = async(id) => {
    return await api.get(`Vaccinated/${id}`).then(res => res.data);
}

// const Login = async(user) => {
//     return await api.post('User/Login', user).then(res => res.data);
// }

const AddVaccinated = async(user) => {
    return await api.post('Vaccinated', user).then(res => res.data);
}

const UpdateVaccinated = async(id, HmoMember) => {
    return await api.put(`Vaccinated/${id}`, HmoMember).then(res => res);
}

const DeleteVaccinated = async(id) => {
    return await api.delete(`Vaccinated/${id}`).then(res => res.data);
}

export {GetAllVaccinateds, GetVaccinatedById, AddVaccinated, UpdateVaccinated, DeleteVaccinated}