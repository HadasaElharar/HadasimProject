// import logo from './logo.svg';
import './App.css';
import { Route, Routes } from 'react-router-dom';
import HmoMembers from './components/HmoMembers';

import AddMember from './components/AddMember';
import Setting from './components/Setting';
import AddOrDeleteVaccine from './components/AddOrDeleteVaccine';
import AddOrDeletePatient from './components/AddOrDeletePatient';


function App() {
  return (
  <Routes>
    <Route path="/" element={<HmoMembers/>}></Route>
    <Route path="/addMember"  element={<AddMember/>}></Route>
    <Route path="/setting/:id"  element={<Setting/>}></Route>
    <Route path="/addOrDeleteVaccine"  element={<AddOrDeleteVaccine/>}></Route>
    <Route path="/addOrDeletePatient"  element={<AddOrDeletePatient/>}></Route>
  </Routes>
  );
}

export default App;
