
//import {useEffect} from "react";
import {useAtom} from "jotai";
import {PapersAtom} from "../atoms/PaperAtom.tsx";
import {useInitializeData} from "../useInitializeData.ts";
import { useNavigate } from 'react-router-dom';
import {http} from "../http";
import { useState } from "react";





export default function Home() {

    const fetchPapersByPrice = () => {
        http.api.paperGetPapersSortedByPrice()
            .then((response) => setPapers(response.data))
            .catch((error) => console.error("Error fetching papers sorted by price:", error));
    };
    const fetchPapersByStock = () => {
        http.api.paperGetPapersSortedByStock()
            .then((response) => setPapers(response.data))
            .catch((error) => console.error("Error fetching papers sorted by stock:", error));
    };
    const fetchPapersByDiscount = () => {
        http.api.paperGetPapersSortedByDiscount()
            .then((response) => setPapers(response.data))
            .catch((error) => console.error("Error fetching papers sorted by discount:", error));
    };

    const navigate = useNavigate();

    
    const [searchQuery, setSearchQuery] = useState("");
    const [papers, setPapers] = useAtom(PapersAtom);


    useInitializeData();

   function handleDiscontinue(id : number | undefined) {
        http.api.paperDiscontinuePaper(Number(id));
        window.location.reload();
   };

    const reloadPapers=()=>{
        http.api.paperGetAllPapers().then((response) => setPapers(response.data))
            .catch((error) => console.error("Error fetching papers:", error))
    }
    const handleSearch = () => {
        http.api.paperSearchPapers({ name: searchQuery }) // Pass as an object with 'name' property
            .then((response) => setPapers(response.data))
            .catch((error) => console.error("Error fetching searched papers:", error));
    };
    
    function handleRestock(id: number | undefined) {
        if (!id) return;
        
        const paper = papers.find((p) => p.id === id);
        if (!paper || paper.stock === undefined) return; 

        const updatedStock = (paper.stock ?? 0) + 50; 
        
        http.api.paperRestockPaper(id, updatedStock)
            .then(() => {
                setPapers((prevPapers) =>
                    prevPapers.map((p) =>
                        p.id === id ? { ...p, stock: updatedStock } : p
                    )
                );
            })
            .catch((error: unknown) => {
                if (error instanceof Error) {
                    console.error("Failed to restock paper:", error.message);
                } else {
                    console.error("An unknown error occurred while restocking paper.");
                }
            });
    }



    return (
        <div>
            <select
                id="paperFilter"
                onChange={(e) => {
                    switch (e.target.value) {
                        case "price":
                            fetchPapersByPrice();
                            break;
                        case "stock":
                            fetchPapersByStock();
                            break;
                        case "discount":
                            fetchPapersByDiscount();
                            break;
                        default:
                            fetchPapersByPrice();
                    }
                }}
                className="mb-5 p-2 border border-gray-300 rounded-md"
            >
                <option value="sort">Sort</option>
                <option value="price">Sort by Price</option>
                <option value="stock">Sort by Stock</option>
                <option value="discount">Sort by Discount</option>
            </select>

            <div>
                <input
                    type="text"
                    value={searchQuery}
                    onChange={(e) => setSearchQuery(e.target.value)}
                    placeholder="Search by name..."

                />
                <button
                    onClick={handleSearch}

                >
                    Search
                </button>
                <button onClick={reloadPapers}>
                    Reset
                </button>
            </div>

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
                                    onClick={() => handleRestock(paper.id)}
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