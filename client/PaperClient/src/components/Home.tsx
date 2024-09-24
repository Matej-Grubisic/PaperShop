import {useEffect} from "react";
import {useAtom} from "jotai";
import {PapersAtom} from "../atoms/PaperAtom.tsx";
import {useInitializeData} from "../useInitializeData.ts";
import {http} from "../http";

export default function Home() {

    const [papers] = useAtom(PapersAtom);

    useEffect(() => {
        
    }, []); 
    
    useInitializeData();

    return (
        <div>
            <h1 className="menu-title text-5xl m-5">The react template</h1>
            <p className="font-bold">This is a template for a react project with Jotai, Typescript, DaisyUI, Vite (& more)</p>
            <ul>
                {papers.map((paper) => (
                    <li key={paper.id}>{paper.name}, {paper.stock}, {paper.price}</li> // Assuming each paper has a `title` property
                ))}
            </ul>
        </div>
    );
}