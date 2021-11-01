import React, { useState } from "react";
import { Link } from "react-router-dom";
import { SidebarData } from "./sideBarData";
import "../../styles/navBar.scss";

function MyNavbar() {
    const [sidebar, setSidebar] = useState(false);

    const showSidebar = () => setSidebar(!sidebar);

    return (
        <div className='menu-bars'>
            <div>
                <Link to='#' className='menu-bars'>
                    <button onClick={showSidebar} >
                     =
                    </button>
                </Link>
            </div>
            <nav className={sidebar ? 'nav-menu active' : 'nav-menu'}>
                <ul className='nav-menu-items' onClick={showSidebar}>
                    <li className='navbar-toggle'>
                        <Link to='#' className='menu-bars'>
                        </Link>
                    </li>
                    {SidebarData.map((item, index) => {
                        return (
                            <li key={index} className={item.cName}>
                                <Link to={item.path}>
                                    <span>{item.title}</span>
                                </Link>
                            </li>
                        );
                    })}
                </ul>
            </nav>
        </div>
    );
}
export default MyNavbar;