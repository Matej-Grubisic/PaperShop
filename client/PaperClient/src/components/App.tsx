import {Route, Routes} from "react-router-dom";
import {Toaster} from "react-hot-toast";
import {DevTools} from "jotai-devtools";
import Navigation from "./Navigation.tsx";
import Home from "./Home.tsx";
import NewProduct from "./NewProduct";
import SingleCustomer from './SingleCustomer';
import Customers from './Customers';
import Orders from "./Orders.tsx";

const App = () => {

    return (<>

        <Navigation/>
        <Toaster position={"bottom-center"}/>
        <Routes>
            <Route path="/Home" element={<Home/>}/>
            <Route path="/new-product" element={<NewProduct/>}/>
            <Route path="/customer/:id" element={<SingleCustomer/>} />
            <Route path="/customers" element={<Customers/>} />
            <Route path="/order" element={<Orders/>} />
        </Routes>
        <DevTools/>

    </>)
}
export default App;