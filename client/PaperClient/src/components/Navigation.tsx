import {Link} from "react-router-dom";
import '../styles.css'


export default function Navigation() {
    return (
        <div className="navbar bg-base-100 h-16 min-h-[4rem]">
            <div className="flex-1">
                <h1>Paper Shop</h1>
            </div>
            <div className="flex-none">
                <Link to={"/Home"}><button>Home</button></Link>
                <Link to={"/customers"}><button>Customers</button></Link>
                <Link to={"/all-orders"}><button>All Orders</button></Link>
                <Link to={"/order"}><button>New Order</button></Link>
                <Link to={"/new-product"}><button>New Product</button></Link>
            </div>
        </div>
    );
}