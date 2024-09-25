import {useEffect} from "react";
import {useAtom} from "jotai";
import {PapersAtom} from "../atoms/PaperAtom.tsx";
import {useInitializeData} from "../useInitializeData.ts";
import { useNavigate } from 'react-router-dom';
import {http} from "../http";

export default function Home() {

    const [papers] = useAtom(PapersAtom);
    
    const navigate = useNavigate()


    useEffect(() => {
        
    }, []); 
    
    useInitializeData();

    return (
        <div>
            <h1 className="menu-title text-5xl m-5">The React Template</h1>
            <p className="font-bold">This is a template for a React project with Jotai, TypeScript, DaisyUI, Vite (& more)</p>

            {/* List of papers */}
            <ul>
                {papers.map((paper) => (
                    <li key={paper.id}>
                        {paper.name}, {paper.stock}, {paper.price}
                    </li>
                ))}
            </ul>

            {/* White New Product Button */}
            <button
                className="btn bg-white text-black border border-gray-300 hover:bg-gray-100" // DaisyUI and custom styles
                onClick={() => navigate('/new-product')}
            >
                New Product
            </button>
        </div>
    );
}