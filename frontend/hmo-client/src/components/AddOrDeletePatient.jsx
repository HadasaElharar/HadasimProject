import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
// import MenuItem from '@mui/material/MenuItem';
// import InputLabel from '@mui/material/InputLabel';
// import Select from '@mui/material/Select';
// import FormControl from '@mui/material/FormControl';
import { AddSick } from '../utils/sickUtil';


const AddOrDeletePatient = () => {
    const [patient, setPatient] = useState({
        id:0,
        memberId: 0,
        postiveDate: "",
        recoveryDate: "",
        
    });

    
    const [error, setError] = useState(""); 
    const navigate = useNavigate();

    const handleChangePatient = (e) => {
        let { name, value} = e.target; 
        let _patient = { ...patient }; 
        console.log(name + " :" + value);
        console.log(_patient);
        _patient[name] = value;
        setPatient(_patient);
       
    }
    // useEffect(() => {
    //     console.log("sign up");
    //     GetAllManufacturers().then((res) => {
    //         setManufacturers(res);
    //     }).catch((err) => {
    //         console.log(err);
    //         console.log("faild get all manufacturers");
    //     })
    // }, []);

    const handleClickAddPatient = () => {
        AddSick(patient).then(() => {
                alert("נוסף בהצלחה");
                navigate('/');
        }).catch((err) => {
            console.error(err);
            setError("Registration failed. Please try again.");
        });
    }

    return (
        <div className='settings'>
            <h1>הוספת חולה חדש</h1>
            <TextField
                fullWidth
                margin="normal"
                id="id"
                name="id"
                type='number'
                label="מספר חולה"
                value={patient.id}
                onChange={handleChangePatient}
            />
            <TextField
                fullWidth
                margin="normal"
                id="memberId"
                type='number'
                name="memberId"
                label="מספר חבר"
                value={patient.memberId}
                onChange={handleChangePatient}
            />
            
            <TextField
                fullWidth
                margin="normal"
                id="postiveDate"
                name="postiveDate"
                label="תאריך חיובי"
                type="date"
                value={patient.postiveDate}
                onChange={handleChangePatient}
                InputLabelProps={{
                    shrink: true,
                }}
            />
            <TextField
                fullWidth
                margin="normal"
                id="recoveryDate"
                name="recoveryDate"
                label="תאריך החלמה"
                type="date"
                value={patient.recoveryDate}
                onChange={handleChangePatient}
                InputLabelProps={{
                    shrink: true,
                }}
            />
            <div>
                {/* <FormControl sx={{ m: 1, width: 300 }}>
                    <InputLabel id="demo-simple-select-label">Manufacturer</InputLabel>
                    <Select
                        labelId="demo-simple-select-label"
                        id="demo-simple-select"
                        value={vaccine.manufacturerId}
                        name="manufacturerId"
                        onChange={handleChangePatient}>
                        {manufacturers.map((manufacturer) =>{
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
                    </FormControl> */}
                    </div>
            <span>{error}</span>
            <Button onClick={handleClickAddPatient} variant="contained">הוספה</Button>
        </div>
    );
};

export default AddOrDeletePatient;
