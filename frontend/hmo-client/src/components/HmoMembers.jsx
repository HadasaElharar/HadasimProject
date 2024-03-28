import React, { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { DeleteHmoMember, GetAllHmoMembers } from '../utils/hmoMemberUtil';
import { DeleteAllVaccinated,  GetVaccinatedById } from '../utils/vaccinatedUtil';
import { DeleteSick, GetSickById } from '../utils/sickUtil';
import SettingIcon from '@mui/icons-material/Settings';
import DeleteIcon from '@mui/icons-material/Delete';
import './HmoMember.css';
// import { GetAllManufacturers } from '../utils/manufacturerUtil';




const HmoMembers = () => {
    const [hmoMembers, setHmoMembers] = useState([]);
    const [vaccinations, setVaccinations] = useState([]);
    const [selectedMember, setSelectedMember] = useState(null);
    const [patients, setPatients] = useState(null);
    const [error, setError] = useState("");
    // const[vaccinatedToDelets,setVaccinatedToDelete]=useState([]);
    // const[patientToDelete, setPatientToDelete]=useState();
   
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
    };
    

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

    const handleEditClick = (id) => {
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
    const handleDeleteMember = async (id) => {

        try {
            await Promise.all([
                DeleteAllVaccinated(id).catch(() => {}),
                DeleteSick(id).catch(() => {}),
                DeleteHmoMember(id)
            ]);
            
    
            setHmoMembers(hmoMembers.filter(member => member.id !== id));
            alert("נמחק בהצלחה");
        } catch (error) {
            console.error(error);
            setError("מחיקת החבר נכשלה. נסה שוב.");
        }
    };

    return (

        <div className="hmo-members-container">
            <div className='sidebar-container div'>
            <div className="sidebar">
                {/* כפתור "הוספת משתמש חדש" */}
                <Link to="/addMember">
                    <button>הוספת חבר חדש</button>
                </Link>
                {/* כפתור "הוספת חיסון חדש" */}
                <Link to="/addOrDeleteVaccine">
                    <button>הוספה/מחיקה מחוסן</button>
                </Link>
                <Link to="/addOrDeletePatient">
                    <button>הוספה/מחיקה חולה קורונה</button>
                </Link>
            </div>
            </div>
            <h1 className="header-container">טבלת חברים</h1>
            <table className="hmo-members-table">
                <thead>
                    <tr>
                        <th></th>
                        <th>עריכת חבר</th>
                        <th>פרטי קורונה</th>
                        <th>חיסונים</th>
                        <th>נייד</th>
                        <th>טלפון</th>
                        <th>תאריך לידה</th>
                        <th>כתובת</th>
                        <th>שם מלא</th>
                        <th>מספר זהות</th>
                        <th>מספר חבר</th>
                    </tr>
                </thead>
                <tbody>
                    {hmoMembers.reverse().map((hmoMember, index) => (
                        <tr key={index} >
                            
                            <td>
                                <button className="table-button" title='למחוק חבר' onClick={() => handleDeleteMember(hmoMember.id)}>
                                    <DeleteIcon />
                                </button>
                            </td>
                            <td>
                                <button className="table-button" onClick={() => handleEditClick(hmoMember.id)}>
                                    <SettingIcon />
                                </button>
                            </td>
                            <td>
                                <button className="table-button" onClick={() => handleShowPatients(hmoMember.id)}>הצג פרטי קורונה</button>
                            </td>
                            <td>
                                <button className="table-button" onClick={() => handleShowVaccinations(hmoMember.id)}>הצג חיסונים</button>
                            </td>
                            <td>{hmoMember.mobile}</td>
                            <td>{hmoMember.phone || '-'}</td>
                            <td>{hmoMember.dateOfBirth}</td>
                            <td>{hmoMember.address}</td>
                            <td>{hmoMember.fullName}</td>
                            <td>{hmoMember.idCivil}</td>
                            <td>{hmoMember.id}</td>
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
                                <h2>רשימת החיסונים לחבר: {selectedMember}</h2>
                                <ul>
                                    {vaccinations.map((vaccination, index) => (
                                        <li key={index}> תאריך החיסון: {vaccination.vaccinDate}, יצרן: {vaccination.manufacturerId}</li>
                                    ))}
                                </ul>
                            </>
                        )}
                        {patients && (
                            <>
                                <h2>פרטי קורונה לחבר: {selectedMember}</h2>
                                <p>
                                    תאריך החולה: {patients.pssitiveDate}<br />
                                    תאריך החלמה: {patients.recoveryDate ? patients.recoveryDate : 'לא נמצא'}
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
