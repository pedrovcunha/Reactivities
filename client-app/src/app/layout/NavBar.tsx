import { observer } from 'mobx-react-lite';
import { Button, Container, Menu } from 'semantic-ui-react';
import { useStore } from '../stores/store';


export default observer(function NavBar() {
    const { openForm } = useStore().activityStore;
    
    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item header>
                    <img src='/assets/logo.png' alt="logo" style={{marginRight: '10px'}}/>
                    Reactivities
                </Menu.Item>
                <Menu.Item name='Activities'/>
                <Menu.Item>
                    <Button onClick={() => openForm()} positive content='Create Actvity'/>
                </Menu.Item>
            </Container>
        </Menu>
    );
})