import React, { useState } from 'react';
import { AddHmoMember } from '../utils/hmoMemberUtil';
import { useNavigate } from 'react-router-dom';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';

import Box from '@mui/material/Box';

const AddMember = () => {
    const [member, setMember] = useState({
        id:0,
        idCivil: 0,
        fullName: "",
        address: "",
        dateOfBirth: "",
        phone: 0,
        mobile: 0,
        chavruta: false,
    });

    const [error, setError] = useState(""); 
    const navigate = useNavigate();

    const handleChangeMember = (e) => {
        const { name, value, checked } = e.target;
        if (name === 'dateOfBirth') {
            // ממירים את התאריך לתבנית YYYY-MM-DD
            const formattedDate = new Date(value).toISOString().split('T')[0];
            // מעדכנים את המשתנה
            setMember(prevState => ({
                ...prevState,
                [name]: formattedDate
            }));
        } else {

        setMember(prevState => ({
            ...prevState,
            [name] : value
        }));
    }
    }

    const handleClickAddMember = () => {
        AddHmoMember(member).then(() => {
            alert("נוסף בהצלחה");
            navigate('/');
        }).catch((err) => {
            console.error(err);
            setError("Registration failed. Please try again.");
        });
    }

    return (
        <div className='settings'>
            <h1>הוספת חבר חדש</h1>
            <TextField
                fullWidth
                margin="normal"
                id="id"
                name="id"
                label="מספר חבר"
                value={member.id}
                onChange={handleChangeMember}
            />
            <TextField
                fullWidth
                margin="normal"
                id="idCivil"
                name="idCivil"
                label="מספר אזרחי"
                value={member.idCivil}
                onChange={handleChangeMember}
            />
            <TextField
                fullWidth
                margin="normal"
                id="fullName"
                name="fullName"
                label="שם מלא"
                value={member.fullName}
                onChange={handleChangeMember}
            />
            <TextField
                fullWidth
                margin="normal"
                id="address"
                name="address"
                label="כתובת"
                value={member.address}
                onChange={handleChangeMember}
            />
            <TextField
                fullWidth
                margin="normal"
                id="dateOfBirth"
                name="dateOfBirth"
                label="תאריך לידה"
                type="date"
                value={member.dateOfBirth}
                onChange={handleChangeMember}
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
                value={member.phone}
                onChange={handleChangeMember}
            />
            <TextField
                fullWidth
                margin="normal"
                id="mobile"
                name="mobile"
                label="נייד"
                type="tel"
                value={member.mobile}
                onChange={handleChangeMember}
            />
            {/* <FormControlLabel
                control={<Checkbox checked={member.chavruta} onChange={handleChangeMember} name="chavruta" />}
                label="חברותא"
            /> */}
            <Box mt={2}>
                <Button variant="contained" onClick={handleClickAddMember}>הוספה</Button>
            </Box>
            {error && <span>{error}</span>}
        </div>
    );
};

export default AddMember;
