import PropTypes from "prop-types";
import Photo from "./Photo.jsx";

const PhotoList = ({list}) => {
    console.log(list);
    return (
        <div>
            {
                list.map(el => <Photo data={el} key={el.id} />)
            }
        </div>
    );
};

export default PhotoList;

PhotoList.propTypes = {
    list: PropTypes.array
};
