import React, { useState } from 'react';
import { http } from "../http"; // Import the HTTP functions
import {CreatePaperDto} from "../Api";
import { useNavigate } from 'react-router-dom';
import { useInitializeData } from '../useInitializeData';
import { useAtom } from 'jotai';
import { PropertyAtom } from '../atoms/PropertyAtom';

export default function NewProduct() {

    useInitializeData()
    
    const [properties] = useAtom(PropertyAtom);
    
    const [name, setProductName] = useState('');
    const [price, setPrice] = useState(0);
    const [stock, setStock] = useState(0);
    const [discontinued, setDiscontinued] = useState(false); // New state for discontinued

    const navigate = useNavigate()
    
    
    var paperDto : CreatePaperDto = {
        name, discontinued , price, stock, properties
    }

    const handleFormSubmit = async (event: React.FormEvent) => {
        event.preventDefault();

        try {
            const response = await http.api.paperCreatePaper(paperDto);
            console.log('New paper created:', response.data);
        } catch (error) {
            console.error('Error creating paper:', error);
        }

        // Reset form after submission
        setProductName('');
        setPrice(0);
        setStock(0);
        setDiscontinued(false); // Reset discontinued state

        navigate('/home');
    };

    return (
        <div className="form-container">
            <h2 className="form-title">Create New Product</h2>
            <form onSubmit={handleFormSubmit} className="product-form">
                <div className="form-group">
                    <label>Product Name:</label>
                    <input
                        type="text"
                        value={name}
                        onChange={(e) => setProductName(e.target.value)}
                        placeholder="Enter product name"
                        required
                    />
                </div>

                <div className="form-group">
                    <label>
                        <input
                            type="checkbox"
                            checked={discontinued}
                            onChange={(e) => setDiscontinued(e.target.checked)} // Update state based on checkbox
                        />
                        Discontinued
                    </label>
                </div>

                <div className="form-group">
                    <label>Price:</label>
                    <input
                        type="number"
                        value={price}
                        onChange={(e) => setPrice(Number(e.target.value))}
                        placeholder="Enter product price"
                        required
                    />
                </div>

                <div className="form-group">
                    <label>Stock:</label>
                    <input
                        type="number"
                        value={stock}
                        onChange={(e) => setStock(Number(e.target.value))}
                        placeholder="Enter stock quantity"
                        required
                    />
                </div>

                <button type="submit" className="submit-button"  >
                    Submit
                </button>
            </form>
        </div>
    );
}