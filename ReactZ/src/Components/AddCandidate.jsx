import { useState, useEffect } from 'react';
import axios from 'axios';
import { toast } from 'react-toastify';

const AddCandidate = ({ onCandidateAdded }) => {
    const [allSkills, setAllSkills] = useState([]);
    const [form, setForm] = useState({
        fullName: '',
        email: '',
        contactNumber: '',
        dateOfBirth: '',
        skillIds: []
    });

    useEffect(() => {
        fetchSkills();
    }, []);

    const fetchSkills = async () => {
        try {
            const response = await axios.get('https://localhost:7219/api/skills');
            setAllSkills(response.data);
        } catch (error) {
            toast.error('Failed to fetch skills');
        }
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await axios.post('https://localhost:7219/api/candidates', form);
            toast.success('Candidate added successfully');
            setForm({
                fullName: '',
                email: '',
                contactNumber: '',
                dateOfBirth: '',
                skillIds: []
            });
            onCandidateAdded();
        } catch (error) {
            toast.error(error.response?.data?.message || 'Failed to add candidate');
        }
    };

    return (
        <div className="border p-4 mb-6 rounded bg-white">
            <h2 className="text-xl font-bold mb-4">Add Candidate</h2>
            <form onSubmit={handleSubmit} className="flex flex-col gap-2">
                <input
                    className="border p-2 rounded"
                    placeholder="Full Name"
                    value={form.fullName}
                    onChange={e => setForm({ ...form, fullName: e.target.value })}
                />
                <input
                    className="border p-2 rounded"
                    placeholder="Email"
                    value={form.email}
                    onChange={e => setForm({ ...form, email: e.target.value })}
                />
                <input
                    className="border p-2 rounded"
                    placeholder="Contact Number"
                    value={form.contactNumber}
                    onChange={e => setForm({ ...form, contactNumber: e.target.value })}
                />
                <input
                    className="border p-2 rounded"
                    type="date"
                    value={form.dateOfBirth}
                    onChange={e => setForm({ ...form, dateOfBirth: e.target.value })}
                />
                <div className="flex flex-wrap gap-2">
                    {allSkills.map(skill => (
                        <label key={skill.id} className="flex items-center gap-1">
                            <input
                                type="checkbox"
                                checked={form.skillIds.includes(skill.id)}
                                onChange={e => {
                                    if (e.target.checked) {
                                        setForm({ ...form, skillIds: [...form.skillIds, skill.id] });
                                    } else {
                                        setForm({ ...form, skillIds: form.skillIds.filter(id => id !== skill.id) });
                                    }
                                }}
                            />
                            {skill.name}
                        </label>
                    ))}
                </div>
                <button
                    type="submit"
                    className="bg-blue-500 text-white px-4 py-2 rounded mt-2"
                >
                    Add Candidate
                </button>
            </form>
        </div>
    );
};

export default AddCandidate;