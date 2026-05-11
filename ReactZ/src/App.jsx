import AddCandidate from './Components/AddCandidate';
import CandidateList from './Components/CandidateList';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useState } from 'react';

function App() {
    const [refresh, setRefresh] = useState(false);

    return (
        <div className="min-h-screen bg-blue-50">
            <div className="max-w-4xl mx-auto py-8">
                <h1 className="text-3xl font-bold text-center text-blue-600 mb-8">
                    HR Platform
                </h1>
                <ToastContainer />
                <AddCandidate onCandidateAdded={() => setRefresh(!refresh)} />
                <CandidateList key={refresh} />
            </div>
        </div>
    );
}

export default App;