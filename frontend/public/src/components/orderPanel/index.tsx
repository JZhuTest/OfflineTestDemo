import React from 'react';
import Card from 'react-bootstrap/Card';
import { Order } from '../../types/Order';
import { OrderItem } from '../../types/OrderItem';
import OrderItemCard from '../orderItemCard';

interface Props {
    order: Order;
    handleOrderItemDeleted: (item: OrderItem) => void;
    handleOrderItemChanged: (items: OrderItem) => void;
  }

const OrderPanel:React.FC<Props> = ({
    order,
    handleOrderItemDeleted,
    handleOrderItemChanged
}) => {

    return (
        <Card style={{ width: '25rem' }}>
            <Card.Header>Order</Card.Header>
            {order.orderItems && order.orderItems.map((item) => (
                <OrderItemCard
                    orderItem={item}
                    handleOrderItemDeleted={handleOrderItemDeleted}
                    handleOrderItemChanged={handleOrderItemChanged}
                    key={item.pizzaTypeId}
                />
            ))}
            <Card.Footer>Total: {order.total}</Card.Footer>
        </Card>
    );
};

export default OrderPanel;