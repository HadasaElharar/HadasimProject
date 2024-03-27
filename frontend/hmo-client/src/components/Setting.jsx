import React, { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import Button from '@mui/material/Button';
import { TextField } from '@mui/material';
import { GetHmoMemberById, UpdateHmoMember } from '../utils/hmoMemberUtil';


const Setting = () => {
    let { id } = useParams();
    const navigate = useNavigate();
    useEffect(() => {
        
        GetHmoMemberById(id).then(res => {
            console.log(res);
            setEditMember(res);
        }).catch((error) =>{
            console.error("Error fetching member data:", error);
            setError("Failed to fetch member data. Please try again.");
        })


    }, [id]);

    const [editMember, setEditMember] = useState({

        idCivil: '',
        fullName: '',
        address: '',
        dateOfBirth: '',
        phone: '',
        mobile: '',   
    });
    const [error, setError] = useState("");

    const handleChangeMember = (e) => {
        const { name, value, type, checked } = e.target;
        setEditMember(prevMember => ({
            ...prevMember,
            [name]: type === 'checkbox' ? checked : value
        }));
    }
    const handleClickSave = () => {
        UpdateHmoMember(editMember.id, editMember).then((res) => {
            if(res.status === 200) {
                alert("הפרטים עודכנו");
                navigate('/'); // ניווט לדף המתאים לאחר העדכון
            }
        }).catch((err) => {
            console.error(err);
            setError("saving the changes failed. Please try again.");
        });
    }
    return (
        <div className='settings'>
            <h1>הגדרות</h1>
            <TextField
                fullWidth
                margin="normal"
                id="idCivil"
                name="idCivil"
                label="מספר אזרחי"
                value={editMember.idCivil}
                onChange={(e) => handleChangeMember(e)}
            />
            <TextField
                //  style={{direction:'rtl'}}
                fullWidth
                margin="normal"
                id="fullName"
                name="fullName"
                label="שם מלא"
                value={editMember.fullName}
                onChange={(e) => handleChangeMember(e)}
            />
            <TextField
                fullWidth
                margin="normal"
                id="address"
                name="address"
                label="כתובת"
                value={editMember.address}
                onChange={(e) => handleChangeMember(e)}
            />
            <TextField
                fullWidth
                margin="normal"
                id="dateOfBirth"
                name="dateOfBirth"
                label="תאריך לידה"
                type="date"
                value={editMember.dateOfBirth}
                onChange={(e) => handleChangeMember(e)}
                InputLabelProps={{
                    shrink: true,
                }}
            />
            <TextField
                fullWidth
                margin="normal"
                id="phone"
                name="phone"
                label="טלפון"
                type="tel"
                value={editMember.phone}
                onChange={(e) => handleChangeMember(e)}
            />
            <TextField
                fullWidth
                margin="normal"
                id="mobile"
                name="mobile"
                label="נייד"
                type="tel"
                value={editMember.mobile}
                onChange={(e) => handleChangeMember(e)}
            />
            <span>{error}</span>
            <Button onClick={handleClickSave} variant="contained">שמירה</Button>
        </div>
    );
}

export default Setting;
