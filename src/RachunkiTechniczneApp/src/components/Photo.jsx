import PropTypes from "prop-types";

const Photo = ({data}) => {
    return (
        <div>
            <img src={data.link} alt={data.description} style={{"maxWidth": "500px"}}/>
            <h3>{data.title}</h3>
            <h4>Tagi: {data.tags}</h4>
            <h4>Opis: {data.description}</h4>
        </div>
    );
};

export default Photo;

Photo.propTypes = {
    data: PropTypes.object
};
