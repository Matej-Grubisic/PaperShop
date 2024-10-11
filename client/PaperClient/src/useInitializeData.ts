import {useAtom} from "jotai";
import {PapersAtom} from "./atoms/PaperAtom";
import {CustomersAtom} from "./atoms/CustomerAtom";
import {useEffect} from "react";
import {http} from "./http.ts";
import { OrdersAtom } from "./atoms/OrderAtom.tsx";
import { AllOrderEntriesAtom } from "./atoms/OrderEntriesAtom.tsx";
import { PropertyAtom } from "./atoms/PropertyAtom.tsx";


export function useInitializeData() {
    
    
    
    const [, setPapers] = useAtom(PapersAtom);
    const [, setCustomers] = useAtom(CustomersAtom);

    const [, setOrders] = useAtom(OrdersAtom);
    const [, setAllOrderEntries] = useAtom(AllOrderEntriesAtom);

    const [, setProperties] = useAtom(PropertyAtom);

    
    useEffect(() => {
        http.api.paperGetAllPapers().then((response) => {
            setPapers(response.data);
        }).catch(e => {
            console.log("Failed to Fetch all papers" + e)
        })
    }, [])
    
    useEffect(() => {
        http.api.customerGetAllCustomers().then((response) => {
            setCustomers(response.data);
        }).catch(e => {
            console.log("Failed to Fetch all customers" + e);
        })
    }, [])


    useEffect(() => {
        http.api.orderGetAllOrders().then((response) => {
            setOrders(response.data);
        }).catch(e => {
            console.log("Failed to Fetch all customers" + e);
        })
    }, [])

    useEffect(() => {
        http.api.orderEntryGetAllOrderEntries().then((response) => {
            setAllOrderEntries(response.data);
        }).catch(e => {
            console.log("Failed to Fetch all papers" + e)
        })
    }, [])
    /*
    useEffect(() => {
        http.api().propertyGetAll.then((response) => {
            setProperties(response.data);

        }).catch(e => {
            console.log("Failed to Fetch all customers" + e);
        })
    }, [])


    useEffect(() => {
        http.api.orderEntryGetAllOrderEntries().then((response) => {
            setAllOrderEntries(response.data);
        }).catch(e => {
            console.log("Failed to Fetch all papers" + e)
        })
    }, [])


    */

    
}

    
