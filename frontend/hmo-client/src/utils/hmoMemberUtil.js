import api from '../api';

const GetAllHmoMembers = async() => {
    return await api.get('HmoMember').then(res => res.data);
}

const GetHmoMemberById = async(id) => {
    return await api.get(`HmoMember/${id}`).then(res => res.data);
}
const GetHmoMemberByIdCivil = async(memberId) => {
    return await api.get(`HmoMember/GetHmoMemberByIdCivil?memberId=${memberId}`).then(res => res.data);
}

// const Login = async(user) => {
//     return await api.post('User/Login', user).then(res => res.data);
// }

const AddHmoMember = async(hmoMember) => {
    return await api.post('HmoMember', hmoMember).then(res => res.data);
}

const UpdateHmoMember = async(id, hmoMember) => {
    return await api.put(`HmoMember/${id}`, hmoMember).then(res => res);
}

const DeleteHmoMember = async(id) => {
    return await api.delete(`HmoMember/${id}`).then(res => res.data);
}

export {GetAllHmoMembers, GetHmoMemberById,GetHmoMemberByIdCivil, AddHmoMember, UpdateHmoMember, DeleteHmoMember}