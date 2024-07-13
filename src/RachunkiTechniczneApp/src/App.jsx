import {BrowserRouter, Route, Routes, Navigate} from "react-router-dom";
import './App.css';
import {default as UserReportView} from "./components/Views/user/ReportView.jsx";
import {default as AdminReportView} from "./components/Views/admin/ReportView.jsx";
import TemplateView from "./components/Views/admin/ChoiceView.jsx";
import LoginView from "./components/Views/LoginView.jsx";
import RegistryViewContract from "./components/Views/admin/RegistryViewContract.jsx";
import RegistryViewAllUser from "./components/Views/admin/RegistryViewAllUser.jsx";
import RegistryViewAddUser from "./components/Views/admin/RegistryViewAddUser.jsx";
import ChoiceView from "./components/Views/admin/ChoiceView.jsx";

import {isAdmin, isLogged} from "./api/index.js"
import RegistryViewEditUser from "./components/Views/admin/RegistryViewEditUser.jsx";
import RegistryViewAddContract from "./components/Views/admin/RegistryViewAddContract.jsx";
import RegistryViewEditContract from "./components/Views/admin/RegistryViewEditContract.jsx";
import AddAnswer from "./components/Views/user/AddAnswer.jsx";

function App() {
    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route exact path="login" element={<LoginView />} />

                    <Route exact path="admin" element={<ChoiceView />} />
                    <Route exact path="admin/report" element={<AdminReportView />} />
                    <Route exact path="admin/registry" element={<RegistryViewContract />} />
                    <Route exact path="admin/registry/add" element={<RegistryViewAddContract />} />
                    <Route exact path="admin/registry/edit" element={<RegistryViewEditContract />} />
                    <Route exact path="admin/users" element={<RegistryViewAllUser />} />
                    <Route exact path="admin/users/add" element={<RegistryViewAddUser />} />
                    <Route exact path="admin/users/edit" element={<RegistryViewEditUser />} />
                    <Route exact path="report" element={<UserReportView />} />
                    <Route exact path="report/answer" element={<AddAnswer />} />

                    { !isLogged()
                        ? <Route path="/" element={<Navigate to="login" replace={true} />}/>
                        : (isAdmin()
                            ? <Route path="/" element={<Navigate to="admin" replace={true} />}/>
                            : <Route path="/" element={<Navigate to="report" replace={true} />}/>)
                    }



                </Routes>
            </BrowserRouter>
        </>
    )
}

export default App
