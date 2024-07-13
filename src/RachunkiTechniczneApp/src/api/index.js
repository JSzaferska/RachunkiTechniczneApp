import {useNavigate} from "react-router-dom";

const url = 'https://localhost:7102';

export const isLogged = () => {
    return localStorage.getItem('jwt-token') !== null;
}

export const getLoginToken = () => {
    return "Bearer " + localStorage.getItem('jwt-token');
}

export const getUsername = () => {
    return localStorage.getItem('login');
}

export const getUserId = () => {
    return localStorage.getItem('userid');
}

export const isAdmin = () => {
    return localStorage.getItem('isAdmin') === "true";
}

export const loggout = () =>
{
    localStorage.clear();
}

export const login = async (username, password, onLoginSuccess, onLoginFail) => {
    console.log(`${url}/api/login`)

    var loginData = {
        login: username,
        password: password,
    };

    const response = await fetch(`${url}/api/login`, {
        method: 'POST',
        body: JSON.stringify(loginData),
        headers: {
            'Content-Type': 'application/json',
        }})
        .then((res) => res.json())
        .then((data) => {
            if (data.status !== "success") {
                localStorage.setItem('jwt-token', data.token);
                localStorage.setItem('userid', data.userId);
                localStorage.setItem('login', data.username);
                localStorage.setItem('isAdmin', data.isAdmin);
                onLoginSuccess();
            } else {
                onLoginFail();
            }
        })
        .catch((error) => {
            console.log('error: ' + error);
            onLoginFail();
        });

    console.log(response);
}

export const getContractsList = (setList) => {
    console.log(`${url}/api/user/contract/` + getUsername())
    fetch(`${url}/api/user/contract/` + getUsername(),
        {
            headers: {
                'Authorization': getLoginToken(),
            }
        })
        .then(res => res.json())
        .then(res => setList(res));
}

export const getContractsListAdmin = (setList) => {
    console.log(`${url}/api/admin/contract`)
    fetch(`${url}/api/admin/contract`,
        {
            headers: {
                'Authorization': getLoginToken(),
            }
        })
        .then(res => res.json())
        .then(res => setList(res));
}

export const getContractsRegistryListAdmin = (setList) => {
    console.log(`${url}/api/admin/registry`)
    fetch(`${url}/api/admin/registry`,
        {
            headers: {
                'Authorization': getLoginToken(),
            }
        })
        .then(res => res.json())
        .then(res => setList(res));
}

export const getUsersRegistryListAdmin = (setList) => {
    console.log(`${url}/api/admin/user`)
    fetch(`${url}/api/admin/user`,
        {
            headers: {
                'Authorization': getLoginToken(),
            }
        })
    .then(res => res.json())
    .then(res => setList(res));
}

export const addUser = async (formData) => {
    console.log(formData);
    const response = await fetch(`${url}/api/admin/user`, {
        method: 'POST',
        body: JSON.stringify(formData),
        headers: {
            'Content-Type': 'application/json',
            'Authorization': getLoginToken()
        }
    })
    console.log(response);
    return response.status;
}

export const removeUser = async (id) => {
    console.log(id);
    const response = await fetch(`${url}/api/admin/user?id=` + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': getLoginToken()
        }
    })
    console.log(response);
    return response.status;
}

export const getUser = (id, setList) => {
    console.log(`${url}/api/admin/user/` + id)
    fetch(`${url}/api/admin/user/` + id,
        {
            headers: {
                'Authorization': getLoginToken(),
            }
        })
        .then(res => res.json())
        .then(res => setList(res));
}

export const getRegistry = (id, setList) => {
    console.log(`${url}/api/admin/registry/` + id)
    fetch(`${url}/api/admin/registry/` + id,
        {
            headers: {
                'Authorization': getLoginToken(),
            }
        })
        .then(res => res.json())
        .then(res => setList(res));
}

export const removeRegistry = async (id) => {
    console.log(id);
    const response = await fetch(`${url}/api/admin/registry?id=` + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': getLoginToken()
        }
    })
    console.log(response);
    return response.status;
}

export const addRegistry = async (formData) => {
    console.log(formData);
    const response = await fetch(`${url}/api/admin/registry`, {
        method: 'POST',
        body: JSON.stringify(formData),
        headers: {
            'Content-Type': 'application/json',
            'Authorization': getLoginToken()
        }
    })
    console.log(response);
    return response.status;
}

export const addAnswer = async (formData) => {
    console.log(formData);
    const response = await fetch(`${url}/api/user/contract`, {
        method: 'PUT',
        body: JSON.stringify(formData),
        headers: {
            'Content-Type': 'application/json',
            'Authorization': getLoginToken()
        }
    })
    console.log(response);
    return response.status;
}