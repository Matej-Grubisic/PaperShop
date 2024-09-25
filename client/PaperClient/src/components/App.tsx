import {Route, Routes} from "react-router-dom";
import React, {useEffect} from "react";
import {Toaster} from "react-hot-toast";
import {DevTools} from "jotai-devtools";
import Navigation from "./Navigation.tsx";
import {useAtom} from "jotai";
import Home from "./Home.tsx";
import NewProduct from "./NewProduct"

const App = () => {

    return (<>

        <Navigation/>
        <Toaster position={"bottom-center"}/>
        <Routes>
            <Route path="/Home" element={<Home/>}/>
            <Route path="/new-product" element={<NewProduct/>}/>
        </Routes>
        <DevTools/>

    </>)
}
export default App;