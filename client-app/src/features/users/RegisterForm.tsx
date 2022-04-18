import { ErrorMessage, Form, Formik } from 'formik';
import { observer } from 'mobx-react-lite';
import { Button, Header, Label } from 'semantic-ui-react';
import MyTextInput from '../../app/common/form/MyTextInput';
import { useStore } from '../../app/stores/store';
import * as Yup from 'yup';
import ValidationErrors from '../errors/ValidationErrors';
import { AxiosError } from 'axios';

interface ValidationError {
    error: {
        field: string,
        message: string
    }
}

interface ApiValidationError {
    errors: {
        ['field']: string[]
    }
}

export default observer(function RegisterForm() {
    const { userStore } = useStore();

    const formValidationSchema = Yup.object().shape({
        displayName: Yup.string().required(),
        username: Yup.string().required(),
        email: Yup.string().required(),
        password: Yup.string().required(),
    });

    return (
        <Formik              
            validationSchema={formValidationSchema}
            initialValues={{displayName: '', username: '', email: '', password: ''}}
            onSubmit={(values, {setFieldError, setErrors}) => userStore.register(values).catch((err: any) => {
                setErrors({password: err});   
                })
            } 
        >
            {({handleSubmit, isSubmitting, errors, isValid, dirty, values, getFieldMeta, getFieldProps, getFieldHelpers }) => (
                <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                    <Header as='h2' content='Sign up to Reactivities' color='teal' textAlign='center'/>
                    <MyTextInput name='displayName' placeholder='Display Name'/>                    
                    <MyTextInput name='username' placeholder='Username'/>                    
                    <MyTextInput name='email' placeholder='Email'/>                    
                    <MyTextInput name='password' placeholder='Password' type='password'/>
                    <ErrorMessage
                        name='error' render={() => 
                            <ValidationErrors errors={errors}/>
                        }
                        />

                    {/* {console.log(`isValid: ${isValid}. dirty: ${dirty}. isSubmitting: ${isSubmitting}`)}
                    {console.log(values)}
                    { console.log(getFieldMeta("displayName")) }                        
                    {console.log(getFieldMeta("username"))}    
                    {console.log(getFieldMeta("email"))}    
                    {console.log(getFieldMeta("password"))}     */}
                    
                    <Button disabled={!isValid || !dirty || isSubmitting}
                        loading={isSubmitting} positive content='Register' type='submit'fluid/>
                </Form>
            )}
        </Formik>
    );
})