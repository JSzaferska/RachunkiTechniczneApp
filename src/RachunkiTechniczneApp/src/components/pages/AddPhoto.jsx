import { useState } from 'react';
import {addPhoto} from "../../api/index.js";

const AddPhoto = () => {
    const [data, setData] = useState({
        categoryId: 1,
        title: '',
        link: '',
        tags: '',
        description: '',
        photoFormat: '',
        resolution: '',
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setData({
            ...data,
            [name]: value,
        });
    };

    const handleSubmit = async (e, data) => {
        e.preventDefault();
        console.log(data);
        const res = await addPhoto(data);
        console.log(res);
    };

    return (
        <form onSubmit={(e) => handleSubmit(e, data)}>
            <div>
                <label>Title:</label>
                <input type="text" name="title" value={data.title} onChange={handleChange} required />
            </div>
            <div>
                <label>Link:</label>
                <input type="text" name="link" value={data.link} onChange={handleChange} required />
            </div>
            <div>
                <label>Tags:</label>
                <input type="text" name="tags" value={data.tags} onChange={handleChange} required />
            </div>
            <div>
                <label>Description:</label>
                <textarea name="description" value={data.description} onChange={handleChange} required></textarea>
            </div>
            <div>
                <label>Photo Format:</label>
                <input type="text" name="photoFormat" value={data.photoFormat} onChange={handleChange} required />
            </div>
            <div>
                <label>Resolution:</label>
                <input type="text" name="resolution" value={data.resolution} onChange={handleChange} required />
            </div>
            <button type="submit">Submit</button>
        </form>
    );
};

export default AddPhoto;
