import React,  { useState, useEffect } from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
import { Location } from '../../types/Location';

interface Props {
    fullLocationList: Location[];
    handleLocationChanged: (item: Location) => void;
  }

const LocationCombo:React.FC<Props> = ({
    fullLocationList,
    handleLocationChanged
}) => {
    const [selectedLocationName, setSelectedLocationName] = useState('Select Location')

    const handleOnClick = (location: Location) => {
        setSelectedLocationName(location.name);
        handleLocationChanged(location);
    };

    return (
        <Dropdown>
            <Dropdown.Toggle variant="success" id="dropdown-basic">
                {selectedLocationName}
            </Dropdown.Toggle>

            <Dropdown.Menu>
            {fullLocationList.map((item) => (
                <Dropdown.Item key={item.id} onClick={() => handleOnClick(item)}>
                    {item.name}
                </Dropdown.Item>
                ))}
            </Dropdown.Menu>
        </Dropdown>
    );
};

// LocationCombo.defaultProps = {
//     handleLocationChanged: (a) => {}
// };

// LocationCombo.propTypes = {
//     handleLocationChanged: PropTypes.func
// };

export default LocationCombo;