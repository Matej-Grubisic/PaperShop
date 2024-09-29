//import {useEffect} from 'react';
//import { http } from "../http";
import {CustomersAtom} from '../atoms/CustomerAtom';
import { useAtom } from 'jotai';
import {useInitializeData} from '../useInitializeData'



export default function Customers() {

    const [customers] = useAtom(CustomersAtom);

    useInitializeData();


    return (
        <div className="">
            <ul>
                {customers.map((customer) => (
                    <li key={customer.id}>
                        <h3>{customer.name}</h3>
                        <h4>Email: {customer.email}</h4>
                        <h4>Address: {customer.address}</h4>
                        <br/>
                    </li>
                ))}
            </ul>
        </div>
    );
}

