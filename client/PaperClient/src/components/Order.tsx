//import { http } from "../http";
import '../styles.css';
import {CustomersAtom} from '../atoms/CustomerAtom';
import {PapersAtom} from '../atoms/PaperAtom';

import { useAtom } from 'jotai';
import {useInitializeData} from '../useInitializeData'
import React, {useEffect, useState} from "react";
import {CreateOrderDto, CreateOrderEntryDto, Customer, Paper, OrderEntry} from '../Api';
import { OrderEntriesAtom } from '../atoms/OrderEntriesAtom';
import { http } from '../http';
import toast from "react-hot-toast";


export default function Order() {
    const [customers] = useAtom(CustomersAtom);
    const [papers] = useAtom(PapersAtom);
    const [orderEntries, setOrderEntries] = useAtom(OrderEntriesAtom);
    useInitializeData();
    //papers.find((el) => el.id == 3);
    const [status, setStatus] = useState("");
    const [totalAmount, setTotalAmount] = useState(0);
    const [customer, setCustomer] = useState<Customer>();
    const [product, setProduct] = useState<Paper>();
    const [quantity, setQuantity] = useState(0);
    
    
    
    
    
    const handleFormSubmit = async (event: React.FormEvent) => {
        event.preventDefault()
        
        setStatus("pending");
        let today = new Date();
        let newDate = new Date(new Date().setDate(today.getDate() + 3));
        let deliveryDate = formatDate(newDate);
        
        console.log(deliveryDate);

        if(customer == undefined){
            toast.error("Customer not selected");
        }
    

        let OrderDto : CreateOrderDto = {
            status: status,
            deliveryDate,
            totalAmount,
            customerId: customer.id,
            orderEntries
        }

        try {
            const response = await http.api.orderCreateOrder(OrderDto);
            console.log('New order created:', response.data);
            setTotalAmount(0);
            console.log(totalAmount);
        } catch (error) {
            console.error('Error creating order:', error);
        }
    };
    

     function createEntry() {

        if(product == undefined){
             toast.error("Product not selected");
        }
         
        if(product.stock <= quantity) {
            toast.error('Theres not enough stock!');
        } 
        else{
            let orderEntry : CreateOrderEntryDto = {
                quantity,
                productId : product.id,
            }

            //http.api.orderEntryCreateOrderEntry(orderEntry);
            console.log(orderEntry);
            // @ts-ignore
            setTotalAmount(totalAmount + product.price);
            setOrderEntries([...orderEntries, orderEntry])
            toast.success("Order entry successfully added")
        }
        
    };

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
            
            <br/>
            
            <br/>
            <form onSubmit={handleFormSubmit} className="product-form">

                <div>
                    <label>Choose Customer: </label>
                    <select
                        onChange={(e) => setCustomer(customers.find(c => c.id === Number(e.target.value)) || {} as Customer)}>
                        <option value={undefined}>Choose customer</option>
                        {customers.map((customer) => (
                            <option value={customer.id} key={customer.id}>
                                {customer.name}
                            </option>
                        ))}
                    </select>
                </div>
                <br/>

                <div>
                    <label>Order Entry:</label>
                    <div>
                        <label>Product Name:</label>
                        <select
                            onChange={(e) => setProduct(papers.find(p => p.id === Number(e.target.value)) || {} as Paper)}>
                            <option value={undefined}>Pick a product</option>
                            {papers.filter((p)=>p.discontinued != true).map((paper) => (
                                <option value={paper.id} key={paper.id}>
                                    {paper.name}
                                </option>
                            ))}
                        </select>
                    </div>
                    <div>
                        <label>Quantity:</label>
                        <input
                            type="number"
                            value={quantity}
                            onChange={(e) => setQuantity(Number(e.target.value))}
                            placeholder="Enter product name"
                        />
                    </div>
                    <button type="button" onClick={createEntry}>Add product to order</button>
                </div>
                
                <br/>
                <button type="submit" className="submit-button">Order</button>
            </form>

            <div>
                <p>Current Order entries:</p>
                <div>
                    <ol>
                        {orderEntries.map((orderEntry) => (
                            <li key={orderEntry.productId}>
                                <h3>{papers.find((el) => el.id == orderEntry.productId).name}</h3>
                                <p>quantity: {orderEntry.quantity}</p>
                            </li>
                        ))}
                    </ol>
                </div>
            </div>
        </div>
    );

    
}



