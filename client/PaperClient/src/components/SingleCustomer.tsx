import {useState} from 'react';
import { http } from "../http";
//import {useParams} from "react-router-dom"; // Import the HTTP functions
//import {CreateCustomerDto} from '../Api';
import {SingleCustomerAtom} from '../atoms/CustomerAtom';
import { useAtom } from 'jotai';
import {useNavigate, useParams} from "react-router-dom";
import {useEffect} from "react";
import { OrdersAtom } from "../atoms/OrderAtom";
import { AllOrderEntriesAtom } from "../atoms/OrderEntriesAtom";
import { PapersAtom } from "../atoms/PaperAtom";
import toast from "react-hot-toast";
import { useInitializeData } from "../useInitializeData";



export default function SingleCustomer() {
    
    const [singleCustomer, setSingleCustomer] = useAtom(SingleCustomerAtom);
    const [orders, setOrders] = useAtom(OrdersAtom);
    const [orderEntries] = useAtom(AllOrderEntriesAtom);
    const [papers] = useAtom(PapersAtom);
    useInitializeData();
    
    const [newStatus, setNewStatus] = useState("");
    
    const navigate = useNavigate()

    const {id} = useParams();


    useEffect(() => {
        http.api.customerGetCustomer(Number(id)).then((response)=>{
            setSingleCustomer(response.data);
            console.log(response.data);
        }).catch(e =>{
            console.log("Failed to fetch the customer" + e);
        })
    }, []);

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
    
    function updateStatus(status, orderId){
        http.api.orderUpdateOrder({status, orderId}).then(() => {
            toast.success("Order updated!");
        })
        
    }

    return (
        <div className="">
            <div>
                <h1>Customer:</h1>
                <div key={singleCustomer.id}>
                    <h3>Name: {singleCustomer.name}</h3>
                    <h4>Email: {singleCustomer.email}</h4>
                    <h4>Address: {singleCustomer.address}</h4>
                    <h4>Phone: {singleCustomer.phone}</h4>
                </div>
                <button onClick={() => deleteCustomer(singleCustomer.id)}>Delete profile</button>
            </div>
            <div>
                <h1>Order history:</h1>
                <ol>
                    {orders.filter((o)=>o.customerId == singleCustomer.id).map((order) => (
                        <li key={order.id}>
                            <ul>
                                <li>Order date: {formatDate(order.orderDate)}</li>
                                <li>Delivery date: {order.deliveryDate}</li>
                                <li>
                                    Status: {order.status}
                                    <form onSubmit={() => updateStatus(newStatus, order.id)}>
                                    <input  type="text" placeholder={"change status?"} onChange={(e)=>setNewStatus(e.target.value)}/>
                                    <button type="submit">Change status</button>
                                    </form>
                                </li>
                                <li>Total Amount: {order.totalAmount}</li>
                                <li>Order Entries:</li>
                                <ul>
                                    {orderEntries.filter((oe) => oe.orderId == order.id).map((oe) => (
                                        <li>
                                            <p>Product: {papers.find((p) => p.id == oe.productId).name}</p>
                                            <p>quantity: {oe.quantity}</p>
                                        </li>
                                    ))}
                                </ul>
                            </ul>
                        </li>
                    ))}
                </ol>
            </div>

        </div>
    );

    function deleteCustomer(_id: number | undefined) {

        http.api.customerDeleteCustomer(Number(_id)).then((response) => {
            console.log(response.data);
            navigate('/Home')
        })

    }
}

