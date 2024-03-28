import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import MenuItem from '@mui/material/MenuItem';
import InputLabel from '@mui/material/InputLabel';
import Select from '@mui/material/Select';
import FormControl from '@mui/material/FormControl';
import { AddVaccinated, DeleteVaccinated } from '../utils/vaccinatedUtil';
import { GetAllManufacturers } from '../utils/manufacturerUtil';

const AddOrDeleteVaccine = () => {
    const [vaccine, setVaccine] = useState({
        id: 0,
        memberId: 0,
        vaccineDate: "",
        manufacturerId: 0,

    });

    const [manufacturers, setManufacturers] = useState([]);
    const [error, setError] = useState("");
    const navigate = useNavigate();

    const handleChangeVaccine = (e) => {
        let { name, value } = e.target;
        let _vaccine = { ...vaccine };
        console.log(name + " :" + value);
        console.log(_vaccine);
        _vaccine[name] = value;
        setVaccine(_vaccine);

    }
    useEffect(() => {
        console.log("sign up");
        GetAllManufacturers().then((res) => {
            setManufacturers(res);
        }).catch((err) => {
            console.log(err);
            console.log("faild get all manufacturers");
        })
    }, []);

    const handleClickAddVaccine = () => {
        AddVaccinated(vaccine).then((res) => {
            if (res.status === 200) {
                alert("נוסף בהצלחה");
                navigate('/');
            }
        }).catch((err) => {
            console.error(err);
            setError("Registration failed. Please try again.");
        });
    }
    const handleClickDeleteVaccine = () => {
        DeleteVaccinated(vaccine).then(() => {
            alert("נוסף בהצלחה");
            navigate('/');
        }).catch((err) => {
            console.error(err);
            setError("Registration failed. Please try again.");
        });
    }

    return (
        <div className='settings'>
            <Button onClick={handleClickDeleteVaccine} variant="contained">למחיקת מחוסן</Button>
            <h1>הוספת מחוסן חדש</h1>
            <TextField
                fullWidth
                margin="normal"
                id="id"
                name="id"
                label="מספר חיסון"
                value={vaccine.id}
                onChange={handleChangeVaccine}
            />
            <TextField
                fullWidth
                margin="normal"
                id="memberId"
                name="memberId"
                label="מספר חבר"
                value={vaccine.memberId}
                onChange={handleChangeVaccine}
            />

            <TextField
                fullWidth
                margin="normal"
                id="vaccineDate"
                name="vaccineDate"
                label="תאריך החיסון"
                type="date"
                value={vaccine.vaccineDate}
                onChange={handleChangeVaccine}
                InputLabelProps={{
                    shrink: true,
                }}
            />
            <div>
                <FormControl sx={{ m: 1, width: 300 }}>
                    <InputLabel id="demo-simple-select-label">Manufacturer</InputLabel>
                    <Select
                        labelId="demo-simple-select-label"
                        id="demo-simple-select"
                        value={vaccine.manufacturerId}
                        name="manufacturerId"
                        onChange={handleChangeVaccine}>
                        {manufacturers.map((manufacturer) => {
                            return (
                                <MenuItem
                                    key={manufacturer.id}
                                    value={manufacturer.id}
                                >
                                    {manufacturer.desc}
                                </MenuItem>
                            );
                        })}
                    </Select>
                </FormControl>
            </div>
            <Button onClick={handleClickAddVaccine} variant="contained">הוספה</Button>
            <span>{error}</span>
        </div>
    );
};

export default AddOrDeleteVaccine;
