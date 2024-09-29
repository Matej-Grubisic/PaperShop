
import {useEffect} from "react";
import {useAtom} from "jotai";
import {PapersAtom} from "../atoms/PaperAtom.tsx";
import {useInitializeData} from "../useInitializeData.ts";
import { useNavigate } from 'react-router-dom';
import {http} from "../http";





export default function Home() {

    

    const navigate = useNavigate();
    


    const [papers] = useAtom(PapersAtom);
    const navigate = useNavigate()


    useEffect(() => {

    }, []);


    useInitializeData();

   function handleDiscontinue(id : number | undefined) {
        http.api.paperDiscontinuePaper(Number(id));
        window.location.reload();
   };



    return (
        <div>

            
            <ul className="space-y-4">
                {papers.map((paper) => (
                    <li key={paper.id}>
                        <div className="border p-4 rounded shadow-md">
                            <h3 className="text-xl font-semibold">{paper.name}</h3>
                            <p>Stock: {paper.stock}</p>
                            <p>Price: {paper.price}</p>
                            <p>Discontinued: {paper.discontinued ? 'Yes' : 'No'}</p>

                            {/* Action Buttons */}
                            <div className="mt-4 space-x-2">
                                <button
                                    key={paper.id}
                                    className="btn bg-red-500 text-white px-4 py-2 rounded hover:bg-red-600" 
                                    onClick={() => handleDiscontinue(paper.id)}
                                >
                                    Discontinue
                                </button>
                                <button
                                    className="btn bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600"
                                    //onClick={() => handleRestock(paper.id)}
                                >
                                    Restock
                                </button>
                            </div>
                        </div>
                    </li>
                ))}
            </ul>

            
            <button
                className="btn bg-white text-black border border-gray-300 hover:bg-gray-100 mt-8"
                onClick={() => navigate('/new-product')}
            >
                New Product
            </button>
        </div>
    );
}