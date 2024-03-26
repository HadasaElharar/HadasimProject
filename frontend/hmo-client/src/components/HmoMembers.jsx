import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { GetAllHmoMembers } from '../utils/hmoMemberUtil';
import { GetVaccinatedById } from '../utils/vaccinatedUtil';
import { GetSickById } from '../utils/sickUtil';
import SettingIcon from '@mui/icons-material/Settings';
import './HmoMember.css';

const pages = [{ name: "Add Member", url: 'addMember' }];

const HmoMembers = () => {
    const [hmoMembers, setHmoMembers] = useState([]);
    const [vaccinations, setVaccinations] = useState([]);
    const [selectedMember, setSelectedMember] = useState(null);
    const [patients, setPatients] = useState(null);
    const [error, setError] = useState("");
    const navigate = useNavigate();

    useEffect(() => {
        GetAllHmoMembers().then(res => {
            setHmoMembers(res);
        });
    }, []);

    const handleShowVaccinations = async (id) => {
        setSelectedMember(id);
        try {
            const vaccine = await GetVaccinatedById(id);
            
            setVaccinations(vaccine);
            setPatients(null);
            setError("");
        } catch (error) {
            setError("Failed to fetch vaccinations data. Please try again.");
        }
    }

    const handleShowPatients = async (id) => {
        setSelectedMember(id);
        try {
            const patient = await GetSickById(id);
            setPatients(patient);
            setVaccinations([]);
            setError("");
        } catch (error) {
            setError("Failed to fetch patient data. Please try again.");
        }
    };

    const handleButtonClick = (id) => {
        navigate(`/setting/${id}`);
    }

    const handleClosePopup = () => {
        setSelectedMember(null);
        setPatients(null);
        setVaccinations([]);
        setError("");
    }

    const handleCloseErrorPopup = () => {
        setError("");
    }

    return (
        <div className="hmo-members-container">
            <div className="sidebar">
                {pages.map((page, index) => (
                    <button key={index} onClick={() => navigate(page.url)}>הוסף Hmo Member חדש</button>
                ))}
            </div>
            <h1 className="hmo-members-heading">טבלת משתמשים</h1>
            <table className="hmo-members-table">
                <thead>
                    <tr>
                        <th>מספר חבר</th>
                        <th>מספר זהות</th>
                        <th>שם מלא</th>
                        <th>כתובת</th>
                        <th>תאריך לידה</th>
                        <th>טלפון</th>
                        <th>נייד</th>
                        <th>הצג חיסונים</th>
                        <th>הצג פרטי קורונה</th>
                        <th>הגדרות</th>
                    </tr>
                </thead>
                <tbody>
                    {hmoMembers.map((hmoMember, index) => (
                        <tr key={index} >
                            <td>{hmoMember.id}</td>
                            <td>{hmoMember.idCivil}</td>
                            <td>{hmoMember.fullName}</td>
                            <td>{hmoMember.address}</td>
                            <td>{hmoMember.dateOfBirth}</td>
                            <td>{hmoMember.phone || '-'}</td>
                            <td>{hmoMember.mobile}</td>
                            <td>
                                <button onClick={() => handleShowVaccinations(hmoMember.id)}>הצג</button>
                            </td>
                            <td>
                                <button onClick={() => handleShowPatients(hmoMember.id)}>הצג</button>
                            </td>
                            <td>
                                <button onClick={() => handleButtonClick(hmoMember.id)}>
                                    <SettingIcon />
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            {selectedMember && (vaccinations.length > 0 || patients) && (
                <div className="popup">
                    <div className="popup-content">
                        <span className="close" onClick={handleClosePopup}>&times;</span>
                        {vaccinations.length > 0 && (
                            <>
                                <h2>רשימת החיסונים למשתמש: {selectedMember}</h2>
                                <ul>
                                    {vaccinations.map((vaccination, index) => (
                                        <li key={index}> תאריך החיסון: {vaccination.vaccinDate}, יצרן: {vaccination.manufacturerId}</li>
                                    ))}
                                </ul>
                            </>
                        )}
                        {patients && (
                            <>
                                <h2>פרטי קורונה למשתמש: {selectedMember}</h2>
                                <p>
                                    תאריך החולה: {patients.pssitiveDate}<br />
                                    תאריך החלמה: {patients.recoveryDate ? patients.recoveryDate.toLocaleDateString() : 'לא נמצא'}
                                </p>
                            </>
                        )}
                    </div>
                </div>
            )}
            {error && (
                <div className="error-popup">
                    <div className="popup-content">
                        <span className="close" onClick={handleCloseErrorPopup}>&times;</span>
                        <p>{error}</p>
                    </div>
                </div>
            )}
        </div>
    );
}

export default HmoMembers;
