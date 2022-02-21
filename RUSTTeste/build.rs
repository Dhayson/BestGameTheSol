extern crate cbindgen;
extern crate rust2;

use std::env;

fn main() {
    let crate_dir = env::var("CARGO_MANIFEST_DIR").unwrap();

    cbindgen::generate(crate_dir)
        .expect("Unable to generate bindings")
        .write_to_file("rust.h");

    rust2::main::generate("rust.h", None, "DLL", "libfoo.so", "Dll.cs");
}
