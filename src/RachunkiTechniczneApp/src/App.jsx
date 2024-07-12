import {BrowserRouter, Route, Routes} from "react-router-dom";
import Main from "./components/pages/Main.jsx";
import './App.css';
import Header from "./components/common/Header.jsx";
import ReportView from "./components/Views/admin/ReportView.jsx";
import TemplateView from "./components/Views/admin/ChoiceView.jsx";
import LoginView from "./components/Views/LoginView.jsx";
import RegistryViewContract from "./components/Views/admin/RegistryViewContract.jsx";
import RegistryViewAllUser from "./components/Views/admin/RegistryViewAllUser.jsx";
import RegistryViewAddUser from "./components/Views/admin/RegistryViewAddUser.jsx";

function App() {
    return (
        <>
            { /* <ReportView/> */}
            { /* <TemplateView/> */}
            <RegistryViewAddUser/>
        </>
  )
}

export default App
