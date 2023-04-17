import React from 'react';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import { MenuItem } from '../../types/MenuItem';

interface PizzaCardProps {
    menuItem: MenuItem;
    handleAdded: (item: MenuItem) => void;
  }

const PizzaCard:React.FC<PizzaCardProps> = ({
    menuItem,
    handleAdded
}) => {

    return (
        <Card style={{ width: '15rem' }}>
            <Card.Body>
                <Card.Title>{menuItem.pizzaTypeName}</Card.Title>
                <Card.Text>
                    {menuItem.pizzaTypeDesc}
                </Card.Text>
                <Card.Text>
                    Price: ${menuItem.price}
                </Card.Text>
                <Button variant="primary" onClick={() => handleAdded(menuItem)}>Add</Button>
            </Card.Body>
        </Card>
    );
};

export default PizzaCard;