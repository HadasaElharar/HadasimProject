import api from '../api';

const GetAllManufacturers = async() => {
    return await api.get('manufacturer').then(res => res.data);
}

const GetManufacturerById = async(id) => {
    return await api.get(`manufacturer/${id}`).then(res => res.data);
}
// const GetHmoMemberByIdCivil = async(memberId) => {
//     return await api.get(`HmoMember/GetHmoMemberByIdCivil?memberId=${memberId}`).then(res => res.data);
// }

// const Login = async(user) => {
//     return await api.post('User/Login', user).then(res => res.data);
// }

// const AddHmoMember = async(hmoMember) => {
//     return await api.post('HmoMember', hmoMember).then(res => res.data);
// }

// const UpdateHmoMember = async(id, hmoMember) => {
//     return await api.put(`HmoMember/${id}`, hmoMember).then(res => res);
// }

// const DeleteHmoMember = async(id) => {
//     return await api.delete(`HmoMember/${id}`).then(res => res.data);
// }

export {GetAllManufacturers, GetManufacturerById,}