const url = 'https://localhost:7102';

export const getContractsList = (setList) => {
    console.log(`${url}/api/user/contract`)
    fetch(`${url}/api/user/contract`)
        .then(res => res.json())
        .then(res => setList(res));
}

export const getContractsListAdmin = (setList) => {
    console.log(`${url}/api/admin/contract`)
    fetch(`${url}/api/admin/contract`)
        .then(res => res.json())
        .then(res => setList(res));
}

export const getContractsRegistryListAdmin = (setList) => {
    console.log(`${url}/api/admin/registry`)
    fetch(`${url}/api/admin/registry`)
        .then(res => res.json())
        .then(res => setList(res));
}

export const getUsersRegistryListAdmin = (setList) => {
    console.log(`${url}/api/admin/user`)
    fetch(`${url}/api/admin/user`)
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
        }
    })
    console.log(response);
    return response.status;
}
/// /api/Search

export const getPhotos = (searchText, setList) => {
    fetch(`${url}/api/Search?searchTerm=${searchText}`)
        .then(res => res.json())
        .then(res => setList(res))
        .catch(err => console.log(err));
}


export const addPhoto = async (formData) => {
    console.log(formData);
    const response = await fetch(`${url}/api/Photo`, {
        method: "POST",
        body: JSON.stringify(formData),
        headers: {
            'Content-Type': 'application/json',
        }
    })
    console.log(response);
    return response.status;
}