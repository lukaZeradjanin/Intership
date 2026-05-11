import { useState, useEffect } from 'react';
import { getAllCandidates, deleteCandidate } from '../api/CandidatesApi';
import { toast } from 'react-toastify';
import { FaTrash, FaEdit } from 'react-icons/fa';
import axios from 'axios';

const CandidateList = () => {
    const [candidates, setCandidates] = useState([]);
    const [editingId, setEditingId] = useState(null);
    const [editForm, setEditForm] = useState({});
    const [allSkills, setAllSkills] = useState([]);

    useEffect(() => {
        fetchCandidates();
        fetchSkills();
    }, []);

    const fetchCandidates = async () => {
        try {
            const data = await getAllCandidates();
            setCandidates(data);
        } catch (error) {
            toast.error('Failed to fetch candidates');
        }
    };

    const fetchSkills = async () => {
        try {
            const response = await axios.get('https://localhost:7219/api/skills');
            setAllSkills(response.data);
        } catch (error) {
            toast.error('Failed to fetch skills');
        }
    };

    const handleDelete = async (id) => {
        try {
            await deleteCandidate(id);
            setCandidates(candidates.filter(c => c.id !== id));
            toast.success('Candidate deleted successfully');
        } catch (error) {
            toast.error('Failed to delete candidate');
        }
    };

    const handleEditClick = (candidate) => {
        setEditingId(candidate.id);
        setEditForm({
            fullName: candidate.fullName,
            email: candidate.email,
            contactNumber: candidate.contactNumber,
            dateOfBirth: candidate.dateOfBirth.split('T')[0],
            skillIds: allSkills
                .filter(s => candidate.skills.includes(s.name))
                .map(s => s.id)
        });
    };

    const handleEditSave = async (id) => {
        try {
            await axios.put(`https://localhost:7219/api/candidates/${id}`, editForm);
            toast.success('Candidate updated successfully');
            setEditingId(null);
            fetchCandidates();
        } catch (error) {
            toast.error('Failed to update candidate');
        }
    };

    return (
        <div className="p-4">
            <h1 className="text-2xl font-bold mb-4">Candidates</h1>
            {candidates.map(candidate => (
                <div key={candidate.id} className="border p-4 mb-2 rounded">
                    {editingId === candidate.id ? (
                        <div className="flex flex-col gap-2">
                            <input
                                className="border p-1 rounded"
                                value={editForm.fullName}
                                onChange={e => setEditForm({ ...editForm, fullName: e.target.value })}
                                placeholder="Full Name"
                            />
                            <input
                                className="border p-1 rounded"
                                value={editForm.email}
                                onChange={e => setEditForm({ ...editForm, email: e.target.value })}
                                placeholder="Email"
                            />
                            <input
                                className="border p-1 rounded"
                                value={editForm.contactNumber}
                                onChange={e => setEditForm({ ...editForm, contactNumber: e.target.value })}
                                placeholder="Contact Number"
                            />
                            <input
                                className="border p-1 rounded"
                                type="date"
                                value={editForm.dateOfBirth}
                                onChange={e => setEditForm({ ...editForm, dateOfBirth: e.target.value })}
                            />
                            <div className="flex flex-wrap gap-2">
                                {allSkills.map(skill => (
                                    <label key={skill.id} className="flex items-center gap-1">
                                        <input
                                            type="checkbox"
                                            checked={editForm.skillIds.includes(skill.id)}
                                            onChange={e => {
                                                if (e.target.checked) {
                                                    setEditForm({ ...editForm, skillIds: [...editForm.skillIds, skill.id] });
                                                } else {
                                                    setEditForm({ ...editForm, skillIds: editForm.skillIds.filter(id => id !== skill.id) });
                                                }
                                            }}
                                        />
                                        {skill.name}
                                    </label>
                                ))}
                            </div>
                            <div className="flex gap-2">
                                <button
                                    onClick={() => handleEditSave(candidate.id)}
                                    className="bg-green-500 text-white px-3 py-1 rounded"
                                >
                                    Save
                                </button>
                                <button
                                    onClick={() => setEditingId(null)}
                                    className="bg-gray-400 text-white px-3 py-1 rounded"
                                >
                                    Cancel
                                </button>
                            </div>
                        </div>
                    ) : (
                        <>
                            <h2 className="text-xl font-semibold">{candidate.fullName}</h2>
                            <p>{candidate.email}</p>
                            <p>{candidate.contactNumber}</p>
                            <div className="flex gap-2 mt-2">
                                {candidate.skills.map(skill => (
                                    <span key={skill} className="bg-white-100 border px-2 py-1 rounded text-sm">
                                        {skill}
                                    </span>
                                ))}
                            </div>
                            <div className="flex gap-2 mt-2">
                                <button
                                    onClick={() => handleEditClick(candidate)}
                                    className="bg-blue-500 text-white px-3 py-1 rounded"
                                >
                                    <FaEdit />
                                </button>
                                <button
                                    onClick={() => handleDelete(candidate.id)}
                                    className="bg-red-500 text-white px-3 py-1 rounded"
                                >
                                    <FaTrash />
                                </button>
                            </div>
                        </>
                    )}
                </div>
            ))}
        </div>
    );
};

export default CandidateList;