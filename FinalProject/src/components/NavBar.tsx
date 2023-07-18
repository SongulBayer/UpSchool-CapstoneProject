import {Container, Menu, Image, Icon, Button} from "semantic-ui-react";
import {NavLink, useNavigate} from "react-router-dom";
import {useContext} from "react";
import { AppUserContext } from "../context/StateContext";
import React from "react";


/*export type NavbarProps = {

}*/

const NavBar = () => {
    const { appUser, setAppUser } = useContext(AppUserContext);
    const navigate = useNavigate();
    
    const handleLogout = () => {

        localStorage.removeItem("upstorage_user");
        setAppUser(undefined);
        navigate("/loginPage");

    }

    return (
        <Menu fixed='top' inverted>
            <Container>
                <Menu.Item as='a' header>
                    <Image size='mini' src='/vite.svg' style={{ marginRight: '1.5em' }} />
                    UpSchool-FinalProject
                </Menu.Item>
            
                <Menu.Item as={NavLink} to="/">Home</Menu.Item>
                <Menu.Item as={NavLink} to="/orderPage">Orders</Menu.Item>
            
                {!appUser && <Menu.Item as={NavLink} to="/loginPage" position="right">Login Page</Menu.Item>}
                {appUser && <Menu.Item as={Button} onClick={handleLogout} position="right"><Icon name="sign-out" /> Logout</Menu.Item>}
      
            </Container>
        </Menu>
    );
}

export default  NavBar;