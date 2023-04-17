import React from 'react';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import { OrderItem } from '../../types/OrderItem';
import { TopIngredient } from '../../types/TopIngredient';
import TopMultiSelect from '../topMultiSelect';

interface Props {
    orderItem: OrderItem;
    handleOrderItemDeleted: (item: OrderItem) => void;
    handleOrderItemChanged: (items: OrderItem) => void;
  }

const OrderItemCard:React.FC<Props> = ({
    orderItem,
    handleOrderItemDeleted,
    handleOrderItemChanged
}) => {

    const handleTopsChanged = (tops: TopIngredient[]) => {
        const item = orderItem;
        item.topIngredients = tops;
        handleOrderItemChanged(item);
    };

    return (
        <Card style={{ width: '25rem' }} key={orderItem.pizzaTypeId}>
            <Card.Body>
                <Card.Title>{orderItem.pizzaTypeName}</Card.Title>
                <Card.Text>Tops: 
                <TopMultiSelect
                    selectedTops={orderItem.topIngredients}
                    handleTopSelectionChanged={handleTopsChanged}
                />
                </Card.Text>
                <Card.Text>
                    Subtotal: ${orderItem.subTotal}
                </Card.Text>
                <Button variant="primary" onClick={() => handleOrderItemDeleted(orderItem)}>Remove</Button>
            </Card.Body>
        </Card>
    );
};

export default OrderItemCard;