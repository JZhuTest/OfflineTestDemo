import React from 'react';
import CardGroup from 'react-bootstrap/CardGroup';
import { MenuItem } from '../../types/MenuItem';
import PizzaCard from '../pizzaCard';

interface MenuProps {
    menuItems: MenuItem[];
    handleOrderItemAdded: (item: MenuItem) => void;
  }

const Menu:React.FC<MenuProps> = ({
    menuItems,
    handleOrderItemAdded
}) => {

    return (
        <CardGroup>
            {menuItems.map((item) => (
                <PizzaCard
                    menuItem={item}
                    handleAdded={handleOrderItemAdded}
                    key={item.pizzaTypeId}
                />
            ))}
        </CardGroup>
    );
};

export default Menu;