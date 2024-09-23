import {useAtom} from "jotai";
import {PapersAtom} from "./atoms/PaperAtom";
import {useEffect} from "react";
//import {http} from "./http.ts";

export function useInitializeData() {
    
    const [, setPatients] = useAtom(PapersAtom);
    
    
    useEffect(() => {
        /*http.api.paperCreatePatient().then((response) => {
            setPatients(response.data);
        }).catch(e => {
            console.log(e)
        })
        */
    }, [])
}