import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Route, Routes,RouterProvider } from 'react-router-dom';
import HmoMembers from './components/HmoMembers';
import HmoTable from './components/HmoTable';
import AddMember from './components/AddMember';
import Setting from './components/Setting';


function App() {
  return (
  <Routes>
    {/* <Route path='/' element ={<login/>}></Route> */}
    <Route path="/" element={<HmoMembers/>}></Route>
    {/* <Route path ="/" element ={<HmoTable/>}></Route> */}
    <Route path="/addMember"  element={<AddMember/>}></Route>
    <Route path="/setting/:id"  element={<Setting/>}></Route>
  </Routes>
  );
}

export default App;
