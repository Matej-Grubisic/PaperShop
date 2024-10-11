import '../styles.css';
import {CustomersAtom} from '../atoms/CustomerAtom';
import {PapersAtom} from '../atoms/PaperAtom';
import { useAtom } from 'jotai';
import {useInitializeData} from '../useInitializeData'
//import React, { useState } from "react";
import {Customer, Paper} from '../Api';
import {AllOrderEntriesAtom, OrderEntriesAtom} from '../atoms/OrderEntriesAtom';
import {OrdersAtom} from '../atoms/OrderAtom';
//import React, {useEffect} from "react";
//import { http } from '../http';
//import toast from "react-hot-toast";


export default function AllOrders() {
    
    const [customers] = useAtom(CustomersAtom);
    const [papers] = useAtom(PapersAtom);
    const [orderEntries] = useAtom(AllOrderEntriesAtom);
    const [orders] = useAtom(OrdersAtom);
    useInitializeData();

    

    function formatDate(date) {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

        if (month.length < 2)
            month = '0' + month;
        if (day.length < 2)
            day = '0' + day;

        return [year, month, day].join('-');
    }


    return (
        <div className="">
            <h2>All orders:</h2>
            <ol>
                {orders.map((order) => (
                    <li key={order.id}>
                        <h3>Customer: {customers.find((c)=> c.id == order.customerId).name}</h3>
                        <ul>
                            <li>Order date: {formatDate(order.orderDate)}</li>
                            <li>Delivery date: {order.deliveryDate}</li>
                            <li>Status: {order.status}</li>
                            <li>Total Amount: {order.totalAmount}</li>
                            <li>Order Entries:</li>
                            <ul>
                            {orderEntries.filter((oe)=>oe.orderId == order.id).map((oe)=>(
                                <li>
                                    <p>Product: {papers.find((p)=>p.id == oe.productId).name}</p>
                                    <p>quantity: {oe.quantity}</p>
                                </li>
                            ))}
                            </ul>
                        </ul>
                    </li>
                ))}
            </ol>
        </div>
    );


}



