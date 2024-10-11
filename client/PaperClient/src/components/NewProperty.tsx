import React, { useState } from 'react';
import { http } from "../http"; // Import the HTTP functions
import { useNavigate } from 'react-router-dom';
import {CreatePropertyDto} from "../Api";
export default function NewProperty() {

    const [propertyName, setPropertyName] = useState('');

    const navigate = useNavigate()

    var propertyDto : CreatePropertyDto = {

        propertyName
    }
    
    const handleFormSubmit = async (event: React.FormEvent) => {
        event.preventDefault();

        try {
            const response = await http.api.propertyCreateProperty(propertyDto)
            console.log('New paper created:', response.data);
        } catch (error) {
            console.error('Error creating paper:', error);
        }

        // Reset form after submission
        setPropertyName('');

        navigate('/home');
    };
    return (
        <div className="form-container">
            <h2 className="form-title">Create New Property</h2>
            <form onSubmit={handleFormSubmit} className="product-form">
                <div className="form-group">
                    <label>Product Name:</label>
                    <input
                        type="text"
                        value={propertyName}
                        onChange={(e) => setPropertyName(e.target.value)}
                        placeholder="Enter product name"
                        required
                    />
                </div>

                <button type="submit" className="submit-button">
                    Submit
                </button>
            </form>
        </div>

    );
}