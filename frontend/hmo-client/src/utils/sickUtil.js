import api from '../api';

const GetAllSick = async() => {
    return await api.get('Sick').then(res => res.data);
}

const GetSickById = async(id) => {
    return await api.get(`Sick/${id}`).then(res => res.data);
}

// const Login = async(user) => {
//     return await api.post('User/Login', user).then(res => res.data);
// }

const AddSick = async(user) => {
    return await api.post('Sick', user).then(res => res.data);
}

const UpdateSick = async(id, HmoMember) => {
    return await api.put(`Sick/${id}`, HmoMember).then(res => res);
}

const DeleteSick = async(id) => {
    return await api.delete(`Sick/${id}`).then(res => res.data);
}

export {GetAllSick, GetSickById, AddSick, UpdateSick, DeleteSick}