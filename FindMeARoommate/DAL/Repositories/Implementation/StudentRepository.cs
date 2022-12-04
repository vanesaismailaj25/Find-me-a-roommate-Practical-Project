using FindMeARoommate.DAL.Context;
using FindMeARoommate.DAL.Entities;
using FindMeARoommate.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindMeARoommate.DAL.Repositories.Implementation;

public class StudentRepository : IStudentRepository
{
    protected FindMeARoomateContext _context;

    public StudentRepository(FindMeARoomateContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        //nqs nuk do te kishim nje dependeny injection ne program.cs
        //_context = FindMeARoomateContext;
    }
    public async Task<Student> AddAsync(Student student)
    {
        var result = await _context.Students.AddAsync(student);
        _ = await _context.SaveChangesAsync();
         
        // bent return result me vleren output qe kthen ndersa return student ben return vete inputin qe merr
        return result.Entity;
        //return student;
    }

    public async Task<Student> DeleteAsync(int studentId)
    {
        //merr entitetin students fillimisht pastaj ben remove
        //var entity = _context.Students.FirstOrDefault(x=>x.Id == studentId);

        // mund te perdorim dhe kete metode
        var entity = await GetAsync(studentId);
        var result = _context.Students.Remove(entity);
        _ = await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Student> GetAsync(int studentId)
    {
        //ketu vec lexon pra merr te dhena, nuk ndyshon.
        var result = await _context.Students.FirstOrDefaultAsync(s=>s.Id ==studentId);

        return result;
    }

    public async Task<List<Student>> GetAsync()
    {
        var result = await _context.Students.ToListAsync();
        return result;
    }

    public async Task<Student> UpdateAsync(Student student)
    {
       var result = _context.Students.Update(student);
        _ = await _context.SaveChangesAsync();

        //kthen si rezultat studentin e updateuar me te dhenat e reja
        return result.Entity;
    }
}
