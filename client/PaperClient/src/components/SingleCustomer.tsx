//import {useEffect} from 'react';
import { http } from "../http";
//import {useParams} from "react-router-dom"; // Import the HTTP functions
//import {CreateCustomerDto} from '../Api';
import {SingleCustomerAtom} from '../atoms/CustomerAtom';
import { useAtom } from 'jotai';
import {useNavigate, useParams} from "react-router-dom";
import {useEffect} from "react";



export default function SingleCustomer() {
    
    const [singleCustomer, setSingleCustomer] = useAtom(SingleCustomerAtom);

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
                <div>
                    Here lies order history
                </div>
            </div>
            
        </div>
    );

    function deleteCustomer(_id: number | undefined){

        http.api.customerDeleteCustomer(Number(_id)).then((response)=>{
            console.log(response.data);
            navigate('/Home')
        })

    }
}

