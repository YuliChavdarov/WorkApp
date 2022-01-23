import * as React from 'react';
import CssBaseline from '@mui/material/CssBaseline';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Container from '@mui/material/Container';
import Toolbar from '@mui/material/Toolbar';
import Paper from '@mui/material/Paper';
import Stepper from '@mui/material/Stepper';
import Step from '@mui/material/Step';
import StepLabel from '@mui/material/StepLabel';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Welcome from './Welcome';
import AboutYou from './AboutYou';
import HourlyRate from './HourlyRate';
import LastDetails from './LastDetails';
import Copyright from '../Copyright';

import { Link as RouterLink } from 'react-router-dom';
import CreateProfileContext from '../../contexts/CreateProfileContext';
import { createProfile } from '../../services/ProfileService';
import AuthContext from '../../contexts/AuthContext';

const steps = ['Welcome', 'About you', 'Hourly rate', 'Last details'];

export default function CreateProfile() {

    const [activeStep, setActiveStep] = React.useState(0);
    const authContext = React.useContext(AuthContext);
    const { infoState, addToState } = React.useContext(CreateProfileContext);
    

    function getStepContent(step: number) {
        switch (step) {
            case 0:
                return <Welcome />;
            case 1:
                return <AboutYou />;
            case 2:
                return <HourlyRate />;
            case 3:
                return <LastDetails />;
            default:
                throw new Error('Unknown step');
        }
    }

    const handleNext = () => {
        setActiveStep(activeStep + 1);
    };

    const handleBack = () => {
        setActiveStep(activeStep - 1);
    };

    const handleCreateProfile = async () => {

        const jwtToken = authContext.getJwtToken();

        if(!jwtToken) {
            console.log("Log in to your account");
            return;
        }

        const response = await createProfile(jwtToken, infoState);

        if (!response?.errors) {
            handleNext();
        }
        else {
            console.log(response.errors);
        }
    }

    return (
        <>
            <CssBaseline />
            <AppBar
                position="absolute"
                color="default"
                elevation={0}
                sx={{
                    position: 'relative',
                    borderBottom: (t) => `1px solid ${t.palette.divider}`,
                }}
            >
                <Toolbar>
                    <Typography variant="h6" color="inherit" noWrap>
                        WorkApp
                    </Typography>
                </Toolbar>
            </AppBar>

            <Container component="main" maxWidth="sm" sx={{ mb: 4 }}>
                <Paper variant="outlined" sx={{ my: { xs: 3, md: 6 }, p: { xs: 2, md: 3 } }}>
                    <Stepper activeStep={activeStep} sx={{ pt: 3, pb: 5 }}>
                        {steps.map((label) => (
                            <Step key={label}>
                                <StepLabel>{label}</StepLabel>
                            </Step>
                        ))}
                    </Stepper>
                    <>
                        {activeStep === steps.length ? (
                            <Box sx={{ textAlign: "center" }}>
                                <Typography variant="h5" gutterBottom>
                                    Thank you for joining us.
                                </Typography>
                                <Typography variant="subtitle1">
                                    Your profile is successfully created. You can now explore job offers
                                    and find new opportunities.
                                </Typography>
                                <Button component={RouterLink} to="/" variant="contained" sx={{ mt: 3 }}>Dashboard</Button>
                            </Box>
                        ) : (
                            <>
                                {getStepContent(activeStep)}

                                <Box sx={{ display: 'flex', justifyContent: 'flex-end' }}>
                                    {activeStep !== 0 && (
                                        <Button onClick={handleBack} sx={{ mt: 3, ml: 1 }}>
                                            Back
                                        </Button>
                                    )}

                                    {activeStep === steps.length - 1
                                        ? <Button variant="contained" onClick={handleCreateProfile} sx={{ mt: 3, ml: 1 }}>
                                            Create Profile
                                        </Button>

                                        : <Button variant="contained" onClick={handleNext} sx={{ mt: 3, ml: 1 }}>
                                            Next
                                        </Button>
                                    }
                            </Box>
                            </>
                        )}
                </>
            </Paper>
            <Copyright />
        </Container>
        </>
    );
}