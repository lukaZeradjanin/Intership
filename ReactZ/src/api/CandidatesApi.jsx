import axios from 'axios';

const API_URL = 'https://localhost:7219/api';

export const getAllCandidates = async () => {
    const response = await axios.get(`${API_URL}/candidates`);
    return response.data;
};

export const addCandidate = async (candidate) => {
    const response = await axios.post(`${API_URL}/candidates`, candidate);
    return response.data;
};

export const deleteCandidate = async (id) => {
    await axios.delete(`${API_URL}/candidates/${id}`);
};

export const searchCandidates = async (name, skillName) => {
    const response = await axios.get(`${API_URL}/candidates/search`, {
        params: { name, skillName }
    });
    return response.data;
};